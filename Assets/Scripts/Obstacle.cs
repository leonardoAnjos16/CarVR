using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Player player;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -100f)
            Destroy(gameObject);
    }

    void FixedUpdate() {
        rigidBody.velocity = new Vector3(0f, 0f, -player.speed);
    }
}
