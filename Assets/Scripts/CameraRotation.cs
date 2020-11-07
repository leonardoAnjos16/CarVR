using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Gets current camera rotation
        Vector3 rotation = transform.eulerAngles;

        // Calculates desired rotation angle
        float angle = Input.GetAxis("Mouse X") * Time.deltaTime * speed;

        // Ensures it rotates within interval [-90, 90]
        rotation.y += angle;
        if (rotation.y > 90f && rotation.y < 270f) {
            if (angle < 0) rotation.y = 270f;
            else if (angle > 0) rotation.y = 90f;
        }

        // Change camera rotation
        transform.eulerAngles = rotation;
    }
}
