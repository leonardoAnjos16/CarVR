﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    private const float zPosition = 300f;

    public GameObject[] obstaclePrefabs;

    private Player player;
    private float spawnInterval = 16f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
        StartCoroutine(Spawn());
    }

    // Thread for spwaning obstacles
    private IEnumerator Spawn() {
        yield return new WaitForSeconds(2f);
        System.Random random = new System.Random();

        while (true) {
            GameObject prefab = obstaclePrefabs[random.Next(obstaclePrefabs.Length)];
            Vector3 position = SpawnPosition(prefab, player.lane);

            Instantiate(prefab, position, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = System.Math.Max(spawnInterval - 0.1f, 8f);
        }
    }

    // Defines spawn position based on prefab type and chosen lane
    private Vector3 SpawnPosition(GameObject prefab, StreetLane lane) {
        float yPosition;
        switch (prefab.tag) {
            default:
                yPosition = 0f;
                break;
        }

        switch (lane) {
            case StreetLane.Left:
                return new Vector3(-6f, yPosition, zPosition);
            case StreetLane.Middle:
                return new Vector3(0f, yPosition, zPosition);
            case StreetLane.Right:
                return new Vector3(6f, yPosition, zPosition);
            default:
                return new Vector3(0f, 0f, 0f);
        }
    }
}
