using UnityEngine;
using Cinemachine;

public class AutoRotateCamera : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float rotationSpeed = 10f; // Velocidad de rotación

    void Update()
    {
        // Incrementa el valor del eje X para hacer que la cámara rote alrededor
        freeLookCamera.m_XAxis.Value += rotationSpeed * Time.deltaTime;
    }
}
