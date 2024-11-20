using UnityEngine;

public class Clock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddClock();
            Destroy(gameObject);  // Destruir el reloj después de recogerlo
        }
    }
}
