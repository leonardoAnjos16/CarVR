using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float dirX;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigidbody of the object that has the script
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the axis the user clicked and multiplying by the speed
        dirX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
    }

    //Usually you change the physics in this function
    void FixedUpdate(){
        //Changing the velocity of the object
        rb.velocity = new Vector3(dirX, 0, 0);
    }
}
