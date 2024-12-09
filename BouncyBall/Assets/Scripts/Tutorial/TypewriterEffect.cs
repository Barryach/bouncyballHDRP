using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text textComponent;  // Referencia al TMP del texto
    public float typingSpeed = 0.05f; // Velocidad de la escritura (ajústala a tu gusto)
    private Coroutine currentCoroutine;

    private void Start()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TMP_Text>();
        }
    }

    /// <summary>
    /// Método para iniciar la escritura de texto.
    /// </summary>
    /// <param name="textToType">El texto que se va a escribir</param>
    public void StartTyping(string textToType)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(TypeText(textToType));
    }

    /// <summary>
    /// Corrutina para escribir el texto letra por letra.
    /// </summary>
    /// <param name="textToType">El texto a escribir</param>
    /// <returns></returns>
    private IEnumerator TypeText(string textToType)
    {
        textComponent.text = ""; // Limpia el texto actual
        foreach (char letter in textToType.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Espera antes de escribir la siguiente letra
        }
    }
}
