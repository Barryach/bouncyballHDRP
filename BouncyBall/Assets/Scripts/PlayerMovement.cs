using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float flapForce = 5f;
    private Rigidbody rb;
    public int currentBallType = 1;
    public bool isFlying = false;
    public float flyForce = 10f;
    public float maxFallSpeed = -10f;
    public float gravity = -9.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento normal hacia adelante
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (!isFlying)
        {
            // Salto si est� en el suelo
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        else if (isFlying && currentBallType == 1)
        {
            HandleFlight();
        }
        else if (isFlying && currentBallType == 2)
        {
            HandleInvertedFlight();
        }
        else if (isFlying && currentBallType == 3)
        {
            HandleFlappyFlight();
        }

        // Cambio de tipo de pelota
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeBehaviour(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeBehaviour(-1);
        }
    }

    void FixedUpdate()
    {
    }

    void ChangeBehaviour(int direction)
    {
        currentBallType += direction;
        if (currentBallType > 3) currentBallType = 1;
        if (currentBallType < 1) currentBallType = 3;
    }

    private void HandleFlappyFlight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);
        }
    }

    private void HandleFlight()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * flyForce, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }

        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxFallSpeed, rb.velocity.z);
        }
    }

    private void HandleInvertedFlight()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * flyForce, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }

        if (rb.velocity.y > -maxFallSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, -maxFallSpeed, rb.velocity.z);
        }
    }

    // Manejo de colisiones (con Trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Colisiones con muros de piedra o lava
        if ((other.CompareTag("StoneWall") || other.CompareTag("Lava")) && currentBallType != 3)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.PlayerDied(); 
            }
        }

        // Colisiones con spikes, obst�culos o vac�o
        if (other.CompareTag("Spikes") || other.CompareTag("Obstacle") || other.CompareTag("Void"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.PlayerDied(); 
            }
        }

        // Tocar el portal activa el vuelo
        if (other.CompareTag("Portal"))
        {
            isFlying = !isFlying;  // Cambia el estado de vuelo
        }

        // Tocar la meta carga el men� principal
        if (other.CompareTag("Final"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}