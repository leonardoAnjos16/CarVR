using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float maxSpeed, speed, acceleration;
    private StreetLane _lane;

    public StreetLane lane {
        get => _lane;
        set => _lane = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        maxSpeed = speed = Random.Range(5f, 10f);
        acceleration = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (ObstacleClose(Vector3.forward, out hit)) {
            speed -= acceleration * Time.deltaTime;
            if (hit.collider.tag == "Obstacle") {
                switch (_lane) {
                    case StreetLane.Left:
                        if (!ObstacleClose(Vector3.right, out hit))
                            ChangeLane(StreetLane.Middle);

                        break;
                    case StreetLane.Middle:
                        if (!ObstacleClose(Vector3.left, out hit))
                            ChangeLane(StreetLane.Left);
                        else if (!ObstacleClose(Vector3.right, out hit))
                            ChangeLane(StreetLane.Right);

                        break;
                    case StreetLane.Right:
                        if (!ObstacleClose(Vector3.left, out hit))
                            ChangeLane(StreetLane.Middle);

                        break;
                }
            }
        } else if (speed < maxSpeed) {
            speed += acceleration * Time.deltaTime;
        }

        if (transform.position.z > 300f)
            Destroy(gameObject);
    }

    void FixedUpdate() {
        rigidBody.velocity = new Vector3(0f, 0f, speed);
    }

    public void ChangeLane(StreetLane newLane) {
        _lane = newLane;
        Vector3 position = transform.position;

        switch (_lane) {
            case StreetLane.Left:
                position.x = -6f;
                break;
            case StreetLane.Middle:
                position.x = 0f;
                break;
            case StreetLane.Right:
                position.x = 6f;
                break;
        }

        transform.position = position;
    }

    private bool ObstacleClose(Vector3 direction, out RaycastHit hit) {
        return Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 50f);
    }
}
