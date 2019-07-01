using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public int difficulty;
    public GameObject[] enemyVariant;
    public Transform[] spawnPoints;

    private float spawnDelay;
    private int enemyToBeSpawned;

    // Start is called before the first frame update
    void Start()
    {
        enemyToBeSpawned = 5 + (difficulty * (difficulty - 1));
        spawnDelay = 2f - (difficulty * 1.5f / 10);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        yield return new WaitForSeconds(spawnDelay);

        int randEnemy = Random.Range(0, enemyVariant.Length);
        int randSpawn = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyVariant[randEnemy], spawnPoints[randSpawn].position, spawnPoints[randSpawn].rotation);
        enemyToBeSpawned -= randEnemy + 1;

        if (enemyToBeSpawned <= 0)
        {
            // Finish
        }
        else {
            StartCoroutine(SpawnEnemy());
        }
    }
}
