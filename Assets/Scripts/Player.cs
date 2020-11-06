using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private float speed;
    private float dirX;


    // Start is called before the first frame update
    void Start()
    {
        //Set speed for player 
        speed = 3f;

        //Get rigidbody of the object that has the script
        rb =  GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the axis the user clicked and multiplying by the speed
        dirX = Input.GetAxis("Horizontal") * speed;   
    }


    //Usually you change the physics in this function
    void FixedUpdate(){

        //Changing the velocity of the objec
        rb.velocity = new Vector3(dirX, 0, 0);
    }
}
