using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour
{
    private ESpawner roundManager;
    private float timerValue = 1.5f;

    public void Init(ESpawner _roundmanager)
    {
        roundManager = _roundmanager;
    }

    private void Update()
    {
        timerValue -= Time.deltaTime;
        if (timerValue <= 0f)
        {
            Death();
        }
    }

    private void Death()
    {
        roundManager.RemoveEnemy();
        Destroy(gameObject);
    }
}
