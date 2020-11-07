﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody rigidBody;
    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        // Gets GameController object from the scene
        gameController = FindObjectOfType<GameController>() as GameController;       

        // Gets rigidbody of the object that has the script
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the axis the user clicked and multiply it by the speed
        dirX = Input.GetAxis("Horizontal") * gameController.speed;
    }

    // Usually you make physics-related changes in this function
    void FixedUpdate(){
        //Changing the velocity of the object
        rigidBody.velocity = new Vector3(dirX, 0, 0);
    }
}