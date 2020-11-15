using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float speedMultiplier;
    public Rigidbody rb;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        Debug.Log("Funcionando pelo menos isso");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, 0.2f + gameController.speed);
    }
}
