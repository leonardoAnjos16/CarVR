﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    private const float zPosition = 300f;

    public GameObject[] obstaclePrefabs;

    private float spawnInterval = 16f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Thread for spwaning obstacles
    private IEnumerator Spawn() {
        yield return new WaitForSeconds(2f);

        System.Random random = new System.Random();
        System.Array lanes = System.Enum.GetValues(typeof(StreetLane));

        while (true) {
            GameObject prefab = obstaclePrefabs[random.Next(obstaclePrefabs.Length)];
            StreetLane lane = (StreetLane) lanes.GetValue(random.Next(lanes.Length));
            Vector3 position = SpawnPosition(prefab, lane);
            Quaternion rotation = SpawnRotation(prefab);

            Instantiate(prefab, position, rotation, transform);
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = System.Math.Max(spawnInterval - 1f, 5f);
        }
    }

    // Defines spawn position based on prefab type and chosen lane
    private Vector3 SpawnPosition(GameObject prefab, StreetLane lane) {
        float yPosition;
        switch (prefab.tag) {
            case "Cone":
                yPosition = -0.5f;
                break;
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

    private Quaternion SpawnRotation(GameObject prefab) {
        Vector3 rotation = new Vector3(0f, 0f, 0f);
        switch (prefab.tag) {
            case "Cone":
                rotation.x = -90f;
                break;
            default:
                break;
        }

        return Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
}
