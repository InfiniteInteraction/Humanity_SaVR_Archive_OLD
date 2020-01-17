using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform spawner;
    public GameObject[] spawnpoints;

    //void Start()
    //{
    //    for (int i = 0; i > spawnpoints.Length; i++)
    //    {

    //    }
    //}
    public void SpawnEnemy()
    {

        if (Enemy == null)
        {
            return;
        }
        else
        {
            Instantiate(Enemy, spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
        }
    }
}



