using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    private float _minX = -9;
    private float _maxX = 9;
    private float _minY = -4;
    private float _maxY = 4;
    
    [SerializeField] private float timeToSpawn;
    [Tooltip("Time for spawn")]
    [SerializeField] private float timeDelay;
    [SerializeField] private GameObject prefab;
    
    private ObjectPool objectPool;

    private void Start()
    {
        timeToSpawn = 0f;
        objectPool = FindObjectOfType<ObjectPool>();
    }

    public void Update()
    {
        timeToSpawn = timeToSpawn + 1f * Time.deltaTime;

        if(timeToSpawn >= timeDelay)
        {
                timeToSpawn = 0f;
                CreateEmemy();
        }
       
    }

    public void CreateEmemy()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);

        // Спавнимо префаб на випадковій позиції
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        GameObject newEnemy = objectPool.GetObject(prefab);
        newEnemy.transform.position = spawnPosition;
    }
}
