using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform spawnPoint;
    public float spawnRate = 2f;
    public float minY = -4f, maxY = 4f;

    private void Start()
    {
        Invoke("SpawnObstacle", 1f);
    }

    private void SpawnObstacle()
    {
        int index = Random.Range(0, obstacles.Length);
        Vector3 spawnPos = new Vector3(spawnPoint.position.x, Random.Range(minY, maxY), 0);
        Instantiate(obstacles[index], spawnPos, Quaternion.identity);

        Invoke("SpawnObstacle", spawnRate);
    }
}