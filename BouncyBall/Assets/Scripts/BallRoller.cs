using UnityEngine;

public class BallRoller : MonoBehaviour
{
    public float rotationSpeed = 360f;
    public Transform player;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement.isFlying)
        {
            rotationSpeed = 0;
        }
        else
        {
            rotationSpeed = 360;
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
}
