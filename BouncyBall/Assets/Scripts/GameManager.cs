using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BallChanger ballChanger;
    private int clockCount = 0;
    public float slowMotionDuration = 5f;
    private bool isBoostActive = false;

    public TMP_Text clockCounterText;
    public Transform player;
    public Vector3 startPosition;
    private PlayerMovement playerMovement;

    public GameObject[] clocks;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("¡Más de un GameManager en escena!");
            Destroy(gameObject);
        }
    }


    void Start()
    {
        if (ballChanger == null)
        {
            // Si no se ha asignado BallChanger, lo buscamos automáticamente en la escena
            ballChanger = FindObjectOfType<BallChanger>();
            if (ballChanger == null)
            {
                Debug.LogError("BallChanger no encontrado en la escena.");
            }
        }

        ResetTimeScale();
        UpdateClockCounterUI();
        startPosition = player.position;

        playerMovement = player.GetComponent<PlayerMovement>();

        // Buscar los relojes en la escena por su tag "Reloj"
        clocks = GameObject.FindGameObjectsWithTag("Reloj");
    }

    public void PlayerDied()
    {
        ResetTimeScale();
        player.position = startPosition;
        clockCount = 0;
        UpdateClockCounterUI();
        isBoostActive = false;

        playerMovement.isFlying = false;
        playerMovement.currentBallType = 1;

        // Cambiar a la pelota estándar (1) al morir
        if (ballChanger != null)
        {
            ballChanger.SetBallType(1);  // Cambiar a la bola 1
            ballChanger.currentBallType = 1;
        }
        else
        {
            Debug.LogError("BallChanger no está asignado en el GameManager.");
        }

        // Reactivar los relojes al morir
        ReactivateClocks();
    }

    public void GoToMainMenu()
    {
        ResetTimeScale();
        SceneManager.LoadScene("MainMenu");
    }

    public void AddClock(GameObject clock)
    {
        clockCount++;
        UpdateClockCounterUI();

        if (clockCount >= 3 && !isBoostActive)
        {
            ActivateSlowMotion();
            clockCount = 0;
            UpdateClockCounterUI();
        }

        // Desactivar solo el reloj que se ha recogido
        clock.SetActive(false);
    }

    private void UpdateClockCounterUI()
    {
        if (clockCounterText != null)
        {
            clockCounterText.text = $"Relojes: {clockCount} / 3";
        }
    }

    private void ActivateSlowMotion()
    {
        isBoostActive = true;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Invoke(nameof(ResetTimeScale), slowMotionDuration);
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        isBoostActive = false;
    }

    // Método para reactivar los relojes cuando el jugador muere
    private void ReactivateClocks()
    {
        // Iterar solo sobre los relojes desactivados y activarlos
        foreach (GameObject clock in clocks)
        {
            if (!clock.activeInHierarchy)  // Solo activar los relojes desactivados
            {
                clock.SetActive(true);
            }
        }
    }
}
