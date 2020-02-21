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

    public bool levelOver = true;


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        gameManager = this;
        scoreManager = FindObjectOfType<ScoreManager>();
        levelOver = false;
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

    public void Starsystem()
    {
        if ( levelOver == true)
        {
            StarCalculation();
        }
        else
        {
            return;
        }
    }

    public void StarCalculation()
    {
        ePoints = scoreManager.currScore;
        if (accuracy > 79 && ePoints > 3999 && greenDeaths == 4)
        {
            Debug.Log("5 star rating");
        }
        if (accuracy > 59 && ePoints > 2999 && greenDeaths == 3)
        {
            Debug.Log("4 star rating");
        }
        if (accuracy > 39 && ePoints > 1999 && greenDeaths == 2)
        {
            Debug.Log("3 star rating");
        }
        if (accuracy > 19 && ePoints > 999 && greenDeaths == 1)
        {
            Debug.Log("2 star rating");
        }
        else
        {
            Debug.Log("1 star rating");
        }
    }
}

