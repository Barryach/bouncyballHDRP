using UnityEngine;

public class BallRoller : MonoBehaviour
{
    public float rotationSpeed = 360f;
    private bool isFlying = false;

    void Update()
    {
        if (!isFlying)
        {
            rotationSpeed = 360;
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else 
        {
            rotationSpeed = 0;
            Debug.Log("DEJA DE ROTAR");
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            isFlying = !isFlying;
        }
    }
}   
