using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialStep3 : MonoBehaviour
{
    public TextMeshProUGUI tutorialText; // El texto del tutorial a mostrar
    public GameObject player; // El jugador
    public float typingSpeed = 0.05f; // Velocidad de escritura letra por letra

    private bool isPlayerInTrigger = false; // Para saber si el jugador est� en el trigger
    private bool isTyping = false; // Para saber si se est� escribiendo el texto actualmente
    private BallChanger ballChanger; // El script de cambio de bolas

    void Start()
    {
        ballChanger = player.GetComponent<BallChanger>(); // Obtiene el script BallChanger
        tutorialText.gameObject.SetActive(false); // Aseg�rate de que el texto no est� visible al principio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTyping) // Evita que se active mientras se escribe
        {
            isPlayerInTrigger = true;
            string message = "�Atenci�n! Hay saltos m�s grandes de lo normal en el camino. Solo podr�s saltarlos si te transformas en la pelota de playa, ya que es m�s �gil y ligera. �Prep�rate para saltar m�s alto!";
            tutorialText.gameObject.SetActive(true); // Activa el objeto de texto
            StartCoroutine(TypeText(message)); // Comienza la escritura letra por letra
            Time.timeScale = 0f; // Pausa el juego
        }
    }

    void Update()
    {
        // Verifica si el jugador ha cambiado a la pelota de playa (suponiendo que el tipo 2 es la pelota de playa)
        if (isPlayerInTrigger && ballChanger.currentBallType == 2 && !isTyping)
        {
            // Oculta el texto
            tutorialText.gameObject.SetActive(false);
            // Reanuda el juego
            Time.timeScale = 1f;
            // Desactiva el trigger para que no vuelva a mostrarse
            isPlayerInTrigger = false;
        }
    }

    IEnumerator TypeText(string message)
    {
        isTyping = true; // Indica que el texto se est� escribiendo
        tutorialText.text = ""; // Limpia el texto

        foreach (char letter in message.ToCharArray())
        {
            tutorialText.text += letter; // A�ade una letra cada vez
            yield return new WaitForSecondsRealtime(typingSpeed); // Espera antes de la siguiente letra
        }

        isTyping = false; // Termina la escritura del texto
    }
}
