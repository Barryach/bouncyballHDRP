using UnityEngine;

public class Clock : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Llama al método AddClock y pasa el reloj que se recoge como parámetro
            GameManager.instance.AddClock(gameObject);  // 'gameObject' es el reloj actual

            // Desactivar el reloj (se desactiva, pero no se elimina)
            gameObject.SetActive(false);
        }
    }

}
