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

        speedText.text = "Speed: " + (int) (speed * 18 / 5) + " km/h";

        // Moves according to user input
        Vector3 position = transform.position;
        if (Input.GetKeyUp("left") || Input.GetKeyUp("a")) {
            if (CameraWithinRange(270f, 360f) || CameraWithinRange(0f, 1.5f)) {
                position.x -= 6f;
                if (_lane == StreetLane.Middle)
                    _lane = StreetLane.Left;
                else if (_lane == StreetLane.Right)
                    _lane = StreetLane.Middle;
            } else if (position.x >= 0f) {
                gameController.GameOver("You must always check the rearview before making a turn!");
            }
        } else if (Input.GetKeyUp("right") || Input.GetKeyUp("d")) {
            if (CameraWithinRange(19f, 90f)) {
                position.x += 6f;
                if (_lane == StreetLane.Middle)
                    _lane = StreetLane.Right;
                else if (_lane == StreetLane.Left)
                    _lane = StreetLane.Middle;
            } else if (position.x <= 0f) {
                gameController.GameOver("You must always check the rearview before making a turn!");
            }
        }

        position.x = Mathf.Clamp(position.x, -6f, 6f);
        transform.position = position;

        // Checks game over
        if (speed < 5f)
            gameController.GameOver("You shouldn't move that slow on a highway!");
    }

    void OnCollisionEnter(Collision collision) {
        gameController.GameOver("Oh no! You hit something!");
    }

    bool CameraWithinRange(float start, float end) {
        return Camera.main.transform.eulerAngles.y >= start && Camera.main.transform.eulerAngles.y <= end;
    }
}
