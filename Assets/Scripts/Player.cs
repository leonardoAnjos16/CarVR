using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (gameController.speed < 5f)
            gameController.GameOver();
    }

    void OnCollisionEnter(Collision collision) {
        gameController.GameOver();
    }

    private void Move() {
        Vector3 position = transform.position;

        if (Input.GetKeyUp("left") || Input.GetKeyUp("a")) position.x -= 6f;
        if (Input.GetKeyUp("right") || Input.GetKeyUp("d")) position.x += 6f;

        position.x = Mathf.Clamp(position.x, -6f, 6f);
        transform.position = position;
    }
}
