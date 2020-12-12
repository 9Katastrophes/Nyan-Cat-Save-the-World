using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int totalEnemiesToSpawn = 1;
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;
    private int enemyPrefabIndex = 0;
    public bool randomize = false;

    public float maxOffset = 0.0f;
    public float waveTravelSpeed = 0.0f;
    public float spawnRate = 0.0f;
    private float timeLeftToSpawn;

    private float enemiesAlive;

    void Start()
    {
        timeLeftToSpawn = spawnRate;
        enemiesAlive = 0;
    }

    void Update()
    {
        if (totalEnemiesToSpawn > 0)
        {
            if (timeLeftToSpawn > 0)
            {
                timeLeftToSpawn -= Time.deltaTime;
            }
            else
            {
                if (totalEnemiesToSpawn > 1)
                    SpawnEnemy();
                else // spawn the last enemy, the boss
                    SpawnBoss();
                timeLeftToSpawn = spawnRate;
            }
        }
        if (totalEnemiesToSpawn == 0 && enemiesAlive == 0)
        {
            // player has won the game
            Debug.Log("All enemies defeated!");
        }
    }

    private void SpawnEnemy()
    {
        if (randomize)
            enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        else
            enemyPrefabIndex = (enemyPrefabIndex + 1) % enemyPrefabs.Length;

        Vector3 randomizedY = new Vector3(0.0f, Random.Range(-maxOffset, maxOffset));
        GameObject enemy = Instantiate(enemyPrefabs[enemyPrefabIndex], this.transform.position + randomizedY, Quaternion.identity, this.transform);
        Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();
        enemyRB.velocity = (Vector3.left * waveTravelSpeed);
        totalEnemiesToSpawn--;
        enemiesAlive++;
    }

    private void SpawnBoss()
    {
        GameObject boss = Instantiate(bossPrefab, this.transform);
        Rigidbody2D bossRB = boss.GetComponent<Rigidbody2D>();
        bossRB.velocity = (Vector3.left * waveTravelSpeed);
        totalEnemiesToSpawn--;
        enemiesAlive++;
    }

    public void EnemyKilled()
    {
        enemiesAlive--;
    }
}
