using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    [SerializeField] private SimpleObjectPooling _obstacle;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private bool canSpawn;
    [SerializeField] private Vector2 spawnRangeY = new Vector2(-4f, 4f); 
    [SerializeField] private float spawnX = 10f;

    private float _timer = 0f;
    private int _countObstacles = 0;


    private void Awake()
    {
        _obstacle.SetUp(this.transform);
        _obstacle.onEnableObject += CountSpawnedObstacles;
    }

    private void OnDisable()
    {
        _obstacle.onEnableObject -= CountSpawnedObstacles;
    }

    private void FixedUpdate()
    {
        /*_count += Time.deltaTime;

        if(_count > fireRate && canShoot)
        {
            obstacle.GetObject();

            _count = 0;
        }
*/

        if (!canSpawn) return;

        _timer += Time.deltaTime;

        if (_timer >= spawnRate)
        {
            GameObject obstacle = _obstacle.GetObject();
            float randomY = UnityEngine.Random.Range(spawnRangeY.x, spawnRangeY.y);
            obstacle.transform.position = new Vector3(spawnX, randomY, 0f);

            _timer = 0f;
        }
    }

    private void CountSpawnedObstacles()
    {
        _countObstacles++;
        Debug.Log("Obstáculos generados: " + _countObstacles);
    }
}
