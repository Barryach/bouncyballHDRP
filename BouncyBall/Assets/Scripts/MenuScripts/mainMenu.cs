using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void LevelChose()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("CreditsMenu"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
}
