using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject brokenWallEffect;  // El contenedor de los minicubos que se activarán al romperse la pared
    public GameObject wall;              // La pared que se eliminará al romperse
    public BallChanger ballChanger;      // Referencia al script BallChanger para verificar el tipo de pelota

    void Start()
    {
        // Asegurar que el efecto de pared rota esté desactivado al inicio
        brokenWallEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisión es con el jugador
        if (other.CompareTag("Player"))
        {
            // Verificar si la pelota actual es del tipo 3 utilizando el método público
            if (ballChanger.GetCurrentBallType() == 3)
            {
                DestroyWall();
            }
        }
    }

    void DestroyWall()
    {
        // Desactivar la pared principal
        wall.SetActive(false);

        // Activar el efecto de pared rota
        brokenWallEffect.SetActive(true);

        // Opcional: Destruir la pared después de un tiempo para limpiar la escena
        Destroy(wall, 0.5f);
    }
}
