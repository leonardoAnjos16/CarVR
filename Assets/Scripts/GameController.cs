using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed;
    public float friction;
    public float acceleration;

    // Update is called once per frame
    void Update()
    {
        // Updates speed based on acceleration and user input (up and down arrow clicks)
        speed += Input.GetAxis("Vertical") * acceleration * Time.deltaTime;

        // Decreases speed based on car-street friction
        speed -= friction * Time.deltaTime;

        //Ensures speed stays on interval [0, 20]
        speed = Mathf.Clamp(speed, 0, 20);
    }
}
