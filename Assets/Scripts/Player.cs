using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float FRICTION = 1f;

    private Rigidbody rb;
    private float dirX;

    public float speed;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        // Gets rigidbody of the object that has the script
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the axis the user clicked and multiplying by the speed
        dirX = Input.GetAxis("Horizontal") * speed;

        // Updates speed based on up and down arrow clicks, acceleration and friction
        speed += Input.GetAxis("Vertical") * Time.deltaTime * acceleration;
        speed -= FRICTION * Time.deltaTime;

        // Ensures speed stays in interval [0, 20]
        speed = Mathf.Clamp(speed, 0f, 20f);
    }

    //Usually you change the physics in this function
    void FixedUpdate(){
        //Changing the velocity of the object
        rb.velocity = new Vector3(dirX, 0, speed);
    }
}
