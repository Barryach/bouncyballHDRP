using UnityEngine;

public class BallRoller : MonoBehaviour
{
    public float rotationSpeed = 360f;

    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
