using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameController gameController;
    private StreetLane _lane;

    public StreetLane lane => _lane;

    public float speed, friction, acceleration;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        _lane = StreetLane.Middle;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates speed
        speed += Input.GetAxis("Vertical") * acceleration * Time.deltaTime;
        speed -= friction * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, 20);
        speedText.text= "Speed: " + (int)((speed*18)/5) + " km/h";

        // Moves according to user input
        Vector3 position = transform.position;
        if (Input.GetKeyUp("left") || Input.GetKeyUp("a")) {
            position.x -= 6f;
            if (_lane == StreetLane.Middle)
                _lane = StreetLane.Left;
            else if (_lane == StreetLane.Right)
                _lane = StreetLane.Middle;
        } else if (Input.GetKeyUp("right") || Input.GetKeyUp("d")) {
            position.x += 6f;
            if (_lane == StreetLane.Middle)
                _lane = StreetLane.Right;
            else if (_lane == StreetLane.Left)
                _lane = StreetLane.Middle;
        }

        position.x = Mathf.Clamp(position.x, -6f, 6f);
        transform.position = position;

        // Checks game over
        if (speed < 5f)
            gameController.GameOver("Too slow!");
    }

    void OnCollisionEnter(Collision collision) {
        gameController.GameOver("Hit " + collision.gameObject);
    }
}
