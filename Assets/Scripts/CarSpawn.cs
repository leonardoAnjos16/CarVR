using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    private const float yPosition = -0.02f, zPosition = -200f;

    private float spawnInterval = 10f;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
        System.Array streetLanes = System.Enum.GetValues(typeof(StreetLane));
        System.Random random = new System.Random();

        while (true) {
            Car car = Instantiate(prefab, new Vector3(0f, yPosition, zPosition), Quaternion.identity, transform).GetComponent<Car>();
            car.ChangeLane((StreetLane) streetLanes.GetValue(random.Next(streetLanes.Length)));
            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = System.Math.Max(spawnInterval - 0.5f, 5f);
        }
    }
}
