using UnityEngine;
using TMPro;

public class TutorialStep4 : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;  // El texto del tutorial a mostrar
    public GameObject player;  // El jugador
    private bool isPlayerInTrigger = false;

    private BallChanger ballChanger;  // El script de cambio de bolas

    void Start()
    {
        ballChanger = player.GetComponent<BallChanger>();  // Obtiene el script BallChanger
    }

    void Update()
    {
        if (isPlayerInTrigger && ballChanger.currentBallType == 3)
        {
            // Oculta el texto
            tutorialText.gameObject.SetActive(false);
            // Reanuda el juego
            Time.timeScale = 1f;
            // Desactiva el trigger para que no vuelva a mostrarse
            isPlayerInTrigger = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            tutorialText.text = "¡Cuidado! En el camino encontrarás paredes de roca. Solo podrás destruirlas transformándote en la pelota de roca. ¡No podrás avanzar sin ella!";
            tutorialText.gameObject.SetActive(true);  // Muestra el mensaje al entrar en el trigger
            Time.timeScale = 0f;  // Detenemos el juego
        }
    }
}
