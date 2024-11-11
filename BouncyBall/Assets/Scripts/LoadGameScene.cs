using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    void Update()
    {
        // Verifica si se presiona la tecla Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Carga la escena "GameScene2"
            SceneManager.LoadScene("GameScene2");
        }
    }
}
