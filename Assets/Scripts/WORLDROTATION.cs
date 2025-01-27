using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WORLDROTATION : MonoBehaviour
{
    // Rotation speed for each axis
    public float rotationSpeedX = -10f; // Speed of rotation around X-axis
    public float rotationSpeedY = 0f;  // Speed of rotation around Y-axis
    public float rotationSpeedZ = 0f;  // Speed of rotation around Z-axis

    void Update()
    {
        // Rotate the sphere based on the specified speeds
        transform.Rotate(
            rotationSpeedX * Time.deltaTime,
            rotationSpeedY * Time.deltaTime,
            rotationSpeedZ * Time.deltaTime
        );
    }
}
