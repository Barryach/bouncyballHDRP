using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;    // Cámara virtual principal para cuando el jugador no está volando
    public CinemachineVirtualCamera flyingCamera;  // Cámara virtual para cuando el jugador está volando
    public GameObject player;                      // Referencia al jugador

    private PlayerMovement playerMovement; // Script PlayerMovement para verificar el estado de isFlying

    void Start()
    {
        // Obtener el componente PlayerMovement del jugador
        playerMovement = player.GetComponent<PlayerMovement>();

        // Asegurarse de que la cámara principal esté activa al inicio
        mainCamera.Priority = 10;
        flyingCamera.Priority = 0;
    }

    void Update()
    {
        // Cambiar la prioridad de la cámara dependiendo del estado de vuelo
        if (playerMovement.isFlying)
        {
            SwitchToFlyingCamera();
        }
        else
        {
            SwitchToMainCamera();
        }
    }

    // Activa la cámara de vuelo aumentando su prioridad
    void SwitchToFlyingCamera()
    {
        if (flyingCamera.Priority <= mainCamera.Priority)
        {
            mainCamera.Priority = 0;
            flyingCamera.Priority = 10;
        }
    }

    // Activa la cámara principal aumentando su prioridad
    void SwitchToMainCamera()
    {
        if (mainCamera.Priority <= flyingCamera.Priority)
        {
            flyingCamera.Priority = 0;
            mainCamera.Priority = 10;
        }
    }
}
