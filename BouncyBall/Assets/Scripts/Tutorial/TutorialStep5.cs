using UnityEngine;
using TMPro; // Usamos TextMeshPro

public class TutorialStep5 : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;  // El TextMeshPro con el mensaje
    private bool isPlayerInTrigger = false;  // Para saber si el jugador está en el trigger

    void Start()
    {
        // Asegúrate de que el texto no esté visible al principio
        tutorialText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            // Cambia el texto para el tutorial
            tutorialText.text = "¡Vas a atravesar el portal! Al hacerlo, aparecerán unas alas y podrás volar. Recuerda que cada pelota tiene un comportamiento diferente en el aire, por lo que deberás adaptarte según la que tengas equipada para moverte con facilidad. Presiona enter para continuar";
            tutorialText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        // Espera que el jugador presione la tecla espacio para continuar
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Return))
        {
            // Oculta el texto
            tutorialText.gameObject.SetActive(false);
            // Reanuda el juego
            Time.timeScale = 1f;
            // Desactiva el trigger para que no vuelva a mostrarse
            isPlayerInTrigger = false;
        }
    }
}
