using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CDreyer.Generics;

public class GameManager : MonoBehaviour
{

    [SerializeField] EnemyMovement enemyPref;
    QueuePool<EnemyMovement> enemiesPool;

    [SerializeField] Transform enemiesSpawnPoint;

    [SerializeField] float spawnTimer = 3;
    float curTimer;

    void Start()
    {
        enemiesPool = new(enemyPref, 10);
    }

    private void Update()
    {
        curTimer += Time.deltaTime;
        if (curTimer > spawnTimer)
        {
            SpawnEnemy();
            curTimer = 0;
            spawnTimer -= 0.3f;
        }
    }

    void SpawnEnemy()
    {
        enemiesPool.Get(enemiesSpawnPoint.position, Quaternion.identity);
    }
}