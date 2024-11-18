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
            Debug.Log("�M�s de un GameManager en escena!");
        }
    }

    // M�todo p�blico para reiniciar la escena cuando el jugador muere
    public void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reinicia la escena actual
    }

    // M�todo p�blico para ir al men� principal
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Carga la escena de men� principal
    }
}
