using UnityEngine;

public class BallChanger : MonoBehaviour
{
    public GameObject OrangeBall;
    public GameObject BeachBall;
    public GameObject RockBall;
    public GameObject Wings;

    public Transform player;

    private PlayerMovement playerMovement;

    public int currentBallType = 1;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        SetBallType(1);
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

        activateWings();
    }

    void ChangeBall(int direction)
    {
        currentBallType += direction;
        if (currentBallType > 3) currentBallType = 1;
        if (currentBallType < 1) currentBallType = 3;

        SetBallType(currentBallType);
    }

    void SetBallType(int ballType)
    {
        OrangeBall.SetActive(false);
        BeachBall.SetActive(false);
        RockBall.SetActive(false);

        switch (ballType)
        {
            case 1:
                OrangeBall.SetActive(true);
                playerMovement.speed = 5f;
                playerMovement.jumpForce = 5f;
                break;
            case 2:
                BeachBall.SetActive(true);
                playerMovement.speed = 6f;
                playerMovement.jumpForce = 7f;
                break;
            case 3:
                RockBall.SetActive(true);
                playerMovement.speed = 4f;
                playerMovement.jumpForce = 4f;
                break;
        }
    }

    void activateWings()
    {
        if (playerMovement.isFlying)
        {
            Wings.SetActive(true);
        }
        else
        {
            Wings.SetActive(false);
        }
    }
}
