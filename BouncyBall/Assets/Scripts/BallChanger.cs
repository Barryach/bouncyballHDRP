using UnityEngine;

public class BallChanger : MonoBehaviour
{
    public GameObject[] balls;  // Array para almacenar las pelotas
    public GameObject Wings;

    public Transform player;

    private PlayerMovement playerMovement;
    public int currentBallType = 1;
    public int currentBall = 1;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        SetBallType(1);  // Configurar el tipo de pelota inicial
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeBall(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeBall(-1);
        }

        // Verifica y activa/desactiva alas solo cuando cambia el estado de vuelo
        Wings.SetActive(playerMovement.isFlying);
    }

    void ChangeBall(int direction)
    {
        currentBallType += direction;
        if (currentBallType > balls.Length) currentBallType = 1;
        if (currentBallType < 1) currentBallType = balls.Length;

        SetBallType(currentBallType);
    }

    public void SetBallType(int ballType)
    {
        // Desactivar todas las pelotas
        foreach (var ball in balls)
        {
            ball.SetActive(false);
        }

        // Activar la pelota correspondiente
        balls[ballType - 1].SetActive(true);

        // Configurar atributos según el tipo de pelota
        switch (ballType)
        {
            case 1: // OrangeBall
                playerMovement.speed = 5f;
                playerMovement.jumpForce = 5f;
                break;
            case 2: // BeachBall
                playerMovement.speed = 6f;
                playerMovement.jumpForce = 7f;
                break;
            case 3: // RockBall
                playerMovement.speed = 4f;
                playerMovement.jumpForce = 4f;
                break;
        }
    }

    void activateWings()
    {
        // Activar alas si está volando
        if (playerMovement.isFlying)
        {
            Wings.SetActive(true);
        }
        else
        {
            Wings.SetActive(false);
        }
    }

    // Añadir un método público para acceder al tipo de pelota actual
    public int GetCurrentBallType()
    {
        return currentBallType;
    }

}
