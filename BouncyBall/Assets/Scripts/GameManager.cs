using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int clockCount = 0;  // Contador de relojes
    public float slowMotionDuration = 5f;  // Duración del efecto de boost
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
            Debug.LogWarning("¡Más de un GameManager en escena!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetTimeScale();  // Asegúrate de restaurar el tiempo al iniciar la escena
        UpdateClockCounterUI();  // Asegúrate de mostrar el contador al inicio
    }

    public void PlayerDied()
    {
        ResetTimeScale();  // Restaurar el tiempo al morir
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reinicia la escena actual
    }

    public void GoToMainMenu()
    {
        ResetTimeScale();  // Restaurar el tiempo al volver al menú
        SceneManager.LoadScene("MainMenu");  // Carga la escena de menú principal
    }

    public void AddClock()
    {
        clockCount++;
        UpdateClockCounterUI();  // Actualizar la UI

        if (clockCount >= 3 && !isBoostActive)  // Cambiado a 3 para pruebas
        {
            ActivateSlowMotion();
            clockCount = 0;  // Reiniciar contador tras el boost
            UpdateClockCounterUI();  // Actualizar la UI después de reiniciar
        }
    }

    private void UpdateClockCounterUI()
    {
        if (clockCounterText != null)
        {
            clockCounterText.text = $"Relojes: {clockCount} / 3";  // Cambiado a 3 para pruebas
        }
    }

    private void ActivateSlowMotion()
    {
        isBoostActive = true;
        Time.timeScale = 0.5f;  // Ralentizar tiempo al 50%
        Time.fixedDeltaTime = 0.02f * Time.timeScale;  // Ajustar física
        Invoke(nameof(ResetTimeScale), slowMotionDuration);  // Restaurar tiempo después de la duración
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1f;  // Restaurar tiempo normal
        Time.fixedDeltaTime = 0.02f;  // Restaurar física
        isBoostActive = false;
    }
}
