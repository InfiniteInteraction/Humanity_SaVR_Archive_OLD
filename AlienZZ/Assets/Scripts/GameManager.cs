using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    public int greenDeaths;
    //Enemies score Begins
    ScoreManager scoreManager;
    int ePoints;
    //Enemies score Ends

    //Player Accuracy Begins
    float accuracy;
    float hits;
    float misses;
    float shotsFired;
    //Player Accuracy Ends


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        gameManager = this;
        scoreManager = FindObjectOfType<ScoreManager>();
        ePoints = scoreManager.currScore;
    }


    void Update()
    {
        CalculateAccuracy();
    }

    public void BulletHit()
    {
        hits++;
        shotsFired++;
    }   

    public void BulletMisses()
    {
        misses++;
        shotsFired++;
    }

    public void CalculateAccuracy()
    {
        //if (Input.GetKey(KeyCode.Mouse0))
        {
            accuracy = (hits / shotsFired) * 100;            
        }
    }


}

