using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    private Player player;

    public TerrainLayer terrainLayer;
    public float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = terrainLayer.tileOffset;
        offset.y += player.speed * speedMultiplier * Time.deltaTime;
        terrainLayer.tileOffset = offset;
    }
}
