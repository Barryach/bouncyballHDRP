using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Necesario para TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int clockCount = 0;  // Contador de relojes
    public float slowMotionDuration = 5f;  // Duraci�n del efecto de boost
    private bool isBoostActive = false;

    public TMP_Text clockCounterText;  // Referencia al texto de TextMeshPro

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("�M�s de un GameManager en escena!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateClockCounterUI();  // Asegurarse de mostrar el contador al inicio
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reinicia la escena actual
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Carga la escena de men� principal
    }

    public void AddClock()
    {
        clockCount++;
        UpdateClockCounterUI();  // Actualizar la UI

        if (clockCount >= 3 && !isBoostActive)
        {
            ActivateSlowMotion();
            clockCount = 0;  // Reiniciar contador tras el boost
            UpdateClockCounterUI();  // Actualizar la UI despu�s de reiniciar
        }
    }

    private void UpdateClockCounterUI()
    {
        if (clockCounterText != null)
        {
            clockCounterText.text = $"Relojes: {clockCount} / 5";
        }
    }

    private void ActivateSlowMotion()
    {
        isBoostActive = true;
        Time.timeScale = 0.5f;  // Ralentizar tiempo al 50%
        Time.fixedDeltaTime = 0.02f * Time.timeScale;  // Ajustar f�sica
        Invoke(nameof(ResetTimeScale), slowMotionDuration);  // Restaurar tiempo despu�s de la duraci�n
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1f;  // Restaurar tiempo normal
        Time.fixedDeltaTime = 0.02f;  // Restaurar f�sica
        isBoostActive = false;
    }
}
