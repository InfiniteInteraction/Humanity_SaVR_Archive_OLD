using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform spawner;
    

    public void SpawnEnemy()
    {

        if (Enemy == null)
        {
            return;
        }
        else
        {
            Instantiate(Enemy, spawner.transform.position, Quaternion.identity);
        }
    }
}


