using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;    // C�mara virtual principal para cuando el jugador no est� volando
    public CinemachineVirtualCamera flyingCamera;  // C�mara virtual para cuando el jugador est� volando
    public GameObject player;                      // Referencia al jugador

    private PlayerMovement playerMovement; // Script PlayerMovement para verificar el estado de isFlying

    void Start()
    {
        // Obtener el componente PlayerMovement del jugador
        playerMovement = player.GetComponent<PlayerMovement>();

        // Asegurarse de que la c�mara principal est� activa al inicio
        mainCamera.Priority = 10;
        flyingCamera.Priority = 0;
    }

    void Update()
    {
        // Cambiar la prioridad de la c�mara dependiendo del estado de vuelo
        if (playerMovement.isFlying)
        {
            SwitchToFlyingCamera();
        }
        else
        {
            SwitchToMainCamera();
        }
    }

    // Activa la c�mara de vuelo aumentando su prioridad
    void SwitchToFlyingCamera()
    {
        if (flyingCamera.Priority <= mainCamera.Priority)
        {
            mainCamera.Priority = 0;
            flyingCamera.Priority = 10;
        }
    }

    // Activa la c�mara principal aumentando su prioridad
    void SwitchToMainCamera()
    {
        if (mainCamera.Priority <= flyingCamera.Priority)
        {
            flyingCamera.Priority = 0;
            mainCamera.Priority = 10;
        }
    }
}
