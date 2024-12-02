using UnityEngine;
using TMPro; // Usamos TextMeshPro

public class TutorialStep6 : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;  // El TextMeshPro con el mensaje
    private bool isPlayerInTrigger = false;  // Para saber si el jugador est� en el trigger

    void Start()
    {
        // Aseg�rate de que el texto no est� visible al principio
        tutorialText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            // Cambia el texto para el tutorial
            tutorialText.text = "Recoge relojes a lo largo del camino. Cada vez que consigas tres, el tiempo se ralentizara, d�ndote una ventaja para esquivar los obstaculos y avanzar con m�s facilidad. Presiona enter para continuar";
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
