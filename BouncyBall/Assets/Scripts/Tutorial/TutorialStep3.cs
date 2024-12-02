using UnityEngine;
using TMPro;

public class TutorialStep3 : MonoBehaviour
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
        if (isPlayerInTrigger && ballChanger.currentBallType == 2)
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
            tutorialText.text = "�Atenci�n! Hay saltos m�s grandes de lo normal en el camino. Solo podr�s saltarlos si te transformas en la pelota de playa, ya que es m�s �gil y ligera. �Prep�rate para saltar m�s alto!";
            tutorialText.gameObject.SetActive(true);  // Muestra el mensaje al entrar en el trigger
            Time.timeScale = 0f;  // Detenemos el juego
        }
    }
}
