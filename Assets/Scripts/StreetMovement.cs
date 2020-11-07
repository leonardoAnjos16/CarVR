using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMovement : MonoBehaviour
{
    public float speedMultiplier;

    private GameController gameController;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = renderer.material.GetTextureOffset("_MainTex");
        offset.y -= gameController.speed * speedMultiplier * Time.deltaTime;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(0f, offset.y));
    }
}
