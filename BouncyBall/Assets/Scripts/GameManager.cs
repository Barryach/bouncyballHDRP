using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int clockCount = 0;  // Contador de relojes
    public float slowMotionDuration = 5f;  // Duraci�n del efecto de boost
    private bool isBoostActive = false;  // Si el boost est� activado o no

    public TMP_Text clockCounterText;  // Referencia al texto de TextMeshPro para el contador
    public Transform player;  // Referencia al transform del jugador
    public Vector3 startPosition;  // Posici�n inicial del jugador
    public BallChanger ballChanger;  // Referencia al script BallChanger para cambiar la pelota
    public PlayerMovement playerMovement; // Referencia al script PlayerMovement

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
        ResetTimeScale();  // Aseg�rate de que el tiempo comienza normal
        UpdateClockCounterUI();  // Actualiza la UI para mostrar el contador de relojes
        startPosition = player.position;  // Guarda la posici�n inicial del jugador al inicio
    }

    // M�todo que se llama cuando el jugador muere
    public void PlayerDied()
    {
        ResetTimeScale();  // Restaurar el tiempo al morir
        player.position = startPosition;  // Restaurar la posici�n inicial del jugador

        // Restablecer la pelota a tipo 1 al morir
        if (ballChanger != null)
        {
            ballChanger.SetBallType(2);  // Cambia la pelota a la de tipo 1
        }

        // Reiniciar el contador de relojes y actualizar la UI
        clockCount = 0;
        UpdateClockCounterUI();

        // Desactivar el boost si estaba activo
        isBoostActive = false;

        // Reiniciar el estado de vuelo (isFlying) del jugador
        if (playerMovement != null)
        {
            playerMovement.isFlying = false;  // Asegura que el jugador no est� volando al reiniciar
        }

        // Cualquier otra l�gica necesaria al morir
    }

    public void AddClock()
    {
        clockCount++;
        UpdateClockCounterUI();  // Actualiza el contador de relojes en la UI

        if (clockCount >= 3 && !isBoostActive)
        {
            ActivateSlowMotion();
            clockCount = 0;  // Reiniciamos el contador de relojes
            UpdateClockCounterUI();  // Actualizamos el contador despu�s de reiniciar
        }
    }

    private void UpdateClockCounterUI()
    {
        if (clockCounterText != null)
        {
            clockCounterText.text = $"Relojes: {clockCount} / 3";  // Muestra el contador de relojes
        }
    }

    private void ActivateSlowMotion()
    {
        isBoostActive = true;
        Time.timeScale = 0.5f;  // Reduce la velocidad del tiempo al 50%
        Time.fixedDeltaTime = 0.02f * Time.timeScale;  // Ajusta la f�sica seg�n el tiempo escalado
        Invoke(nameof(ResetTimeScale), slowMotionDuration);  // Restablece el tiempo despu�s de la duraci�n del boost
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1f;  // Restaura el tiempo a la normalidad
        Time.fixedDeltaTime = 0.02f;  // Restaura la f�sica a su valor por defecto
        isBoostActive = false;  // Desactiva el boost
    }
}
