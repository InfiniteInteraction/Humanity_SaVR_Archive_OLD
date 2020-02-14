using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public int enemiesPerSpawner;
    public int currentRound;
    public GameObject[] spawners;


    public int totalEnemiesPerRound;
    private bool isRoundOver;

    //Spawners area 
    public int totalToSpawn = 20;
    public GameObject enemyPrefab;
    public GameObject enemyGreenPrefab;

    public int killCount;
    public int killCountMax = 20;
    //Spawners Area

    void Start()
    {
        InvokeRepeating("DoSpawn", 0.5f, 1.5f);
        
    }

    //Spawners Area Begin//

    public void Spawn(int _totalToSpawn)
    {
        totalToSpawn = _totalToSpawn;
    }

    public void DoSpawn()
    { 
        Instantiate(enemyPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
        
        SpawnCount();
    }

    public void SpawnCount()
    {
        if (totalToSpawn == 0)
        {
            CancelInvoke();
        }
    }

    public void SpawnGreen()
    {
        if (killCount == killCountMax)
        {
            Instantiate(enemyGreenPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
            killCount = 0;
        }
    }

    //Spawners Area End//

    public void StartRound()
    {
        if (isRoundOver)
        {                    
            totalEnemiesPerRound = enemiesPerSpawner * spawners.Length;

            Instantiate(enemyPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);

            isRoundOver = false;
        }
    }
    
    public void RemoveEnemy()
    {
        totalEnemiesPerRound -= 1;
        CheckCount();
    }

    public  void CheckCount()
    {
        if (totalEnemiesPerRound <= 0)
        {
            isRoundOver = true;
            currentRound += 1;
        }
    }
}




