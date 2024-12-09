using UnityEngine;
using TMPro;
using System.Collections; // Necesario para usar corrutinas

public class TutorialStep5 : MonoBehaviour
{
    public TextMeshProUGUI tutorialText; // El TextMeshPro con el mensaje
    public float typingSpeed = 0.05f; // Velocidad de escritura letra por letra
    private bool isPlayerInTrigger = false; // Para saber si el jugador está en el trigger
    private bool isTyping = false; // Para controlar si se está escribiendo el texto

    void Start()
    {
        // Asegúrate de que el texto no esté visible al principio
        tutorialText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTyping) // Evita que se active mientras se escribe
        {
            isPlayerInTrigger = true;
            string message = "¡Vas a atravesar el portal! Al hacerlo, aparecerán unas alas y podrás volar. Recuerda que cada pelota tiene un comportamiento diferente en el aire, por lo que deberás adaptarte según la que tengas equipada para moverte con facilidad. Presiona ENTER para continuar.";
            tutorialText.gameObject.SetActive(true); // Muestra el texto
            StartCoroutine(TypeText(message)); // Comienza la escritura letra por letra
            Time.timeScale = 0f; // Pausa el juego
        }
    }

    void Update()
    {
        // Espera que el jugador presione la tecla ENTER para continuar
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Return) && !isTyping)
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
        isTyping = true; // Indica que el texto se está escribiendo
        tutorialText.text = ""; // Limpia el texto

        foreach (char letter in message.ToCharArray())
        {
            tutorialText.text += letter; // Añade una letra cada vez
            yield return new WaitForSecondsRealtime(typingSpeed); // Espera antes de la siguiente letra
        }

        isTyping = false; // La escritura ha terminado
    }
}
