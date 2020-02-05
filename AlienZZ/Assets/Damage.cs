using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public EnemyHealth[] gO;
    
    private void Awake()
    {
        
        gO = FindObjectsOfType<EnemyHealth>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gO = FindObjectsOfType<EnemyHealth>();
            ScanForEnemy();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void ScanForEnemy()
    {
        foreach (EnemyHealth eH in gO)
        {
            eH.TakeDamage(5);
            return;
        }
    }
   

}
