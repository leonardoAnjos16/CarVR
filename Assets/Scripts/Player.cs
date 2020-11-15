using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKeyUp("left") || Input.GetKeyUp("a")) position.x -= 6f;
        if (Input.GetKeyUp("right") || Input.GetKeyUp("d")) position.x += 6f;

        position.x = Mathf.Clamp(position.x, -6f, 6f);
        transform.position = position;
    }

    void OnCollisionEnter(Collision collision) {
        // Do gameover logic
    }
}
