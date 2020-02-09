using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public GameObject EnemyG;
    public GameObject enemyRed;
    public Transform greenDes;
    public GameObject[] spawnpoints;

    public int killCount;
    public int killCountMax = 20;
    public int eTimer = 5;
    public float sTime;

    void Start()
    {
        killCount = 0;

        Invoke("prefabEnemy", eTimer);
    }
    private void Update()
    {

    }
    public void SpawnEnemy()
    {
        Debug.LogError("Function Called");
        if (enemyRed == null)
        {
            return;
        }
        else
        {
            Instantiate(enemyRed, spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);

            killCount += 1;
        }
        if (killCount == killCountMax)
        {
            killCount = 0;
            Instantiate(EnemyG, spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
        }
    }

    public void prefabEnemy()
    {
        Instantiate(Resources.Load("Prefabs/Enemy_Red"), spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
    }
}




