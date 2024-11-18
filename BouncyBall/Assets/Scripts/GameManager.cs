using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        // Verifica si ya existe una instancia de GameManager
        if (instance == null)
        {
            instance = this;  // Si no existe, asigna esta instancia
        }
        else
        {
            Debug.Log("¡Más de un GameManager en escena!");
        }
    }

    // Método público para reiniciar la escena cuando el jugador muere
    public void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reinicia la escena actual
    }

    // Método público para ir al menú principal
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Carga la escena de menú principal
    }
}
