using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody rigidBody;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        rigidBody = GetComponent<Rigidbody>();
        speed = gameObject.tag == "Car" ? 8f : 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -100f)
            Destroy(gameObject);
    }

    void FixedUpdate() {
        rigidBody.velocity = new Vector3(0f, 0f, speed - 2 * gameController.speed);
    }
}
