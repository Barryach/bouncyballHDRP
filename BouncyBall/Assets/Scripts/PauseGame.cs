using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference pauseAction; // Acci�n para abrir/cerrar el men� de pausa

    [Header("Buttons")]
    public Button resumeButton;
    public Button optionsButton;
    public Button mainMenuButton;

    [Header("Menus")]
    public GameObject pauseMenuCanvas; // Canvas del Men� de Pausa
    public GameObject optionsMenuCanvas; // Canvas del Men� de Opciones

    private bool isPaused = false;

    private void OnEnable()
    {
        // Conectar la acci�n de pausa
        pauseAction.action.Enable();
        pauseAction.action.performed += TogglePauseMenu;

        // Asignar los m�todos a los botones
        resumeButton.onClick.AddListener(ResumeGame);
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void OnDisable()
    {
        // Desconectar la acci�n de pausa
        pauseAction.action.Disable();
        pauseAction.action.performed -= TogglePauseMenu;

        // Eliminar los m�todos de los botones
        resumeButton.onClick.RemoveListener(ResumeGame);
        optionsButton.onClick.RemoveListener(OpenOptionsMenu);
        mainMenuButton.onClick.RemoveListener(GoToMainMenu);
    }

    private void Start()
    {
        // Asegurar que ambos men�s est�n desactivados al inicio
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
        optionsMenuCanvas.SetActive(false); // Asegurarse de que el men� de opciones est� cerrado
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(false); // Cierra cualquier men� de opciones
        Time.timeScale = 1f; // Restaura el flujo normal del tiempo
        isPaused = false;

        // Reactiva la acci�n de pausa al reanudar
        pauseAction.action.Enable(); // Aseg�rate de que la acci�n de pausa est� habilitada de nuevo
    }


    private void OpenOptionsMenu()
    {
        pauseMenuCanvas.SetActive(false); // Oculta el men� de pausa
        optionsMenuCanvas.SetActive(true); // Muestra el men� de opciones
    }

    public void CloseOptionsMenu()
    {
        optionsMenuCanvas.SetActive(false); // Cierra el men� de opciones
        pauseMenuCanvas.SetActive(true); // Vuelve a mostrar el men� de pausa
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}
