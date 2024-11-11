using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference pauseAction; // Acción para abrir/cerrar el menú de pausa

    [Header("Buttons")]
    public Button resumeButton;
    public Button optionsButton;
    public Button mainMenuButton;

    [Header("Menus")]
    public GameObject pauseMenuCanvas; // Canvas del Menú de Pausa
    public GameObject optionsMenuCanvas; // Canvas del Menú de Opciones

    private bool isPaused = false;

    private void OnEnable()
    {
        // Conectar la acción de pausa
        pauseAction.action.Enable();
        pauseAction.action.performed += TogglePauseMenu;

        // Asignar los métodos a los botones
        resumeButton.onClick.AddListener(ResumeGame);
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void OnDisable()
    {
        // Desconectar la acción de pausa
        pauseAction.action.Disable();
        pauseAction.action.performed -= TogglePauseMenu;

        // Eliminar los métodos de los botones
        resumeButton.onClick.RemoveListener(ResumeGame);
        optionsButton.onClick.RemoveListener(OpenOptionsMenu);
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);
    }

    private void Start()
    {
        // Asegurar que ambos menús estén desactivados al inicio
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(false);
    }

    private void TogglePauseMenu(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        optionsMenuCanvas.SetActive(false); // Asegurarse de que el menú de opciones esté cerrado
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(false); // Cierra cualquier menú de opciones
        Time.timeScale = 1f; // Restaura el flujo normal del tiempo
        isPaused = false;

        // Reactiva la acción de pausa al reanudar
        pauseAction.action.Enable(); // Asegúrate de que la acción de pausa esté habilitada de nuevo
    }


    private void OpenOptionsMenu()
    {
        pauseMenuCanvas.SetActive(false); // Oculta el menú de pausa
        optionsMenuCanvas.SetActive(true); // Muestra el menú de opciones
    }

    public void CloseOptionsMenu()
    {
        optionsMenuCanvas.SetActive(false); // Cierra el menú de opciones
        pauseMenuCanvas.SetActive(true); // Vuelve a mostrar el menú de pausa
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}
