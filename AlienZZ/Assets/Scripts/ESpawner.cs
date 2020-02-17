using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    
    public int currentRound;
    public GameObject[] spawners;
    
    private bool isRoundOver;

    //Spawners area 
    public int totalToSpawn = 40;
    public GameObject enemyPrefab;
    public GameObject enemyGreenPrefab;

    public int killCount;
    public int killCountMax = 20;
    //Spawners Area

    void Start()
    {
        InvokeRepeating("DoSpawn", 0.5f, 1.5f);
        totalToSpawn = 40;       
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
            Instantiate(enemyPrefab, spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);

            isRoundOver = false;
        }
    }
    
    public void RemoveEnemy()
    {
        CheckCount();
    }

    public  void CheckCount()
    {
        if (totalToSpawn <= 0)
        {
            isRoundOver = true;
            currentRound += 1;
        }
    }
}




