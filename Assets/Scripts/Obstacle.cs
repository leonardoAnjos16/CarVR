using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -20f) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        rigidBody.velocity = new Vector3(0f, 0f, 5f - gameController.speed);
    }
}
