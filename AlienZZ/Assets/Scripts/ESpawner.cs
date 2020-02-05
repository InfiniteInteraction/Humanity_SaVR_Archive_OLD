using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public GameObject EnemyG;
    public GameObject EnemyR;
    public Transform greenDes;
    public GameObject[] spawnpoints;
    public int killCount = 0;
    public int killCountMax = 20;

    void Start()
    {
        killCount = 0;

        //for (int i = 0; i > spawnpoints.Length; i++)
        //{

        //}
    }
    public void SpawnEnemy()
    {

        if (EnemyR == null)
        {
            return;
        }
        else
        {
            Instantiate(EnemyR, spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);

            killCount += 1;
            //Debug.Log("Killcount: " + killCount);
        }
        if(killCount == killCountMax)
        {
            killCount = 0;
            Instantiate(EnemyG, spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
        }
    }

    
}



