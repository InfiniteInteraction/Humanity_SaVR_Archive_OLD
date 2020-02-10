using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public int enemiesPerSpawner;
    public int currentRound;
    public List<Spawners> spawners = new List<Spawners>();


    private int totalEnemiesPerRound;
    private bool isRoundOver = true;

    private void Start()
    {
       StartRound();
    }

    private void StartRound()
    {
        if (isRoundOver)
        {
                                         //* was  *currentround
            enemiesPerSpawner = enemiesPerSpawner += 1;
            totalEnemiesPerRound = enemiesPerSpawner * spawners.Count;

            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].Spawn(enemiesPerSpawner);
            }

            isRoundOver = false;
        }
    }

    public void RemoveEnemy()
    {
        totalEnemiesPerRound -= 1;
        CheckCount();
    }

    private  void CheckCount()
    {
        if (totalEnemiesPerRound == 0)
        {
            isRoundOver = true;
            currentRound += 1;
            Invoke("StartRound", 5);
        }
    }
}




