using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    private const float zPosition = 300f;

    public GameObject[] obstaclePrefabs;

    private GameController gameController;
    private float spawnInterval = 200f;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        StartCoroutine(Spawn());
    }

    // Thread for spwaning obstacles
    private IEnumerator Spawn() {
        System.Array streetLanes = System.Enum.GetValues(typeof(StreetLane));
        System.Random random = new System.Random();

        while (true) {
            GameObject prefab = obstaclePrefabs[random.Next(obstaclePrefabs.Length)];
            StreetLane lane = (StreetLane) streetLanes.GetValue(random.Next(streetLanes.Length));
            Vector3 position = SpawnPosition(prefab, lane);

            Instantiate(prefab, position, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnInterval / gameController.speed);
            spawnInterval = System.Math.Max(spawnInterval - 2f, 50f);
        }
    }

    // Defines spawn position based on prefab type and chosen lane
    private Vector3 SpawnPosition(GameObject prefab, StreetLane lane) {
        float yPosition;
        switch (prefab.tag) {
            case "Car":
                yPosition = -0.02f;
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
}
