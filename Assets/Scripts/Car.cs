using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float maxSpeed, speed, acceleration, deacceleration;
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
        deacceleration = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (ObstacleClose(Vector3.forward, out hit, 100f)) {
            speed -= deacceleration * Time.deltaTime;
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
                switch (_lane) {
                    case StreetLane.Left:
                        if (!ObstacleClose(Vector3.right, out hit, 10f))
                            ChangeLane(StreetLane.Middle);

                        break;
                    case StreetLane.Middle:
                        if (!ObstacleClose(Vector3.left, out hit, 10f))
                            ChangeLane(StreetLane.Left);
                        else if (!ObstacleClose(Vector3.right, out hit, 10f))
                            ChangeLane(StreetLane.Right);

                        break;
                    case StreetLane.Right:
                        if (!ObstacleClose(Vector3.left, out hit, 10f))
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

    private bool ObstacleClose(Vector3 direction, out RaycastHit hit, float distance) {
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * distance, Color.green);

        bool close = false;
        if (direction == Vector3.left || direction == Vector3.right) {
            for (float angle = 75f; angle >= -75f; angle -= 15f) {
                float cos = (float) System.Math.Cos(System.Math.PI * angle / 180f);
                float sin = (float) System.Math.Sin(System.Math.PI * angle / 180f);
                if (direction == Vector3.left) cos *= -1;

                Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(cos, 0f, sin)) * distance / System.Math.Abs(cos), Color.green);
                close |= Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(cos, 0f, sin)), out hit, distance / System.Math.Abs(cos));
            }
        }

        return Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, distance) || close;
    }
}
