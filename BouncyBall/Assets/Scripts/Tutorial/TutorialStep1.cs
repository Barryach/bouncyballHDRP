using UnityEngine;
using TMPro; // Usamos TextMeshPro
using System.Collections;

public class TutorialStep1 : MonoBehaviour
{
    public TextMeshProUGUI tutorialText; // Referencia al TextMeshPro con el mensaje
    public float typingSpeed = 0.05f; // Velocidad de escritura letra por letra
    private bool isPlayerInTrigger = false; // Para saber si el jugador está en el trigger
    private bool isTyping = false; // Para saber si se está escribiendo el texto actualmente

    void Start()
    {
        // Asegúrate de que el texto no esté visible al principio
        tutorialText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTyping) // Evitar que se vuelva a activar si ya está escribiendo
        {
            isPlayerInTrigger = true;
            // Cambia el texto para el tutorial
            string message = "¡Cuidado con los pinchos! Salta con la tecla ESPACIO para evitarlos.";
            tutorialText.gameObject.SetActive(true); // Activa el objeto de texto
            StartCoroutine(TypeText(message)); // Comienza la escritura letra por letra
            Time.timeScale = 0f; // Pausa el juego
        }
    }

    void Update()
    {
        // Espera que el jugador presione la tecla Enter para continuar
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            // Oculta el texto
            tutorialText.gameObject.SetActive(false);
            // Reanuda el juego
            Time.timeScale = 1f;
            // Desactiva el trigger para que no vuelva a activarse
            isPlayerInTrigger = false;
        }
    }

    IEnumerator TypeText(string message)
    {
        isTyping = true; // Indica que el texto se está escribiendo
        tutorialText.text = ""; // Limpia el texto

        foreach (char letter in message.ToCharArray())
        {
            tutorialText.text += letter; // Añade una letra cada vez
            yield return new WaitForSecondsRealtime(typingSpeed); // Espera un poco antes de la siguiente letra
        }

        isTyping = false; // Termina la escritura del texto
    }
}
