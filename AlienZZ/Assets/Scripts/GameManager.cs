using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    // public varibles for access by other classes
    #region Public 
    public bool levelOver = true;    
    public int greenDeaths;
    public float accuracy;
    public float shotsFired;
    public float hits;

    #endregion

    // private varibles not access by other classes
    #region Private 
    public int score;
    private float misses;
    #endregion





    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        gameManager = this;
        levelOver = false;

    }

    void Update()
    {
        CalculateAccuracy();
        score = ScoreManager.scoreManager.currScore;
    } 

    public void BulletMisses()
    {
        misses++;
    }

    public void CalculateAccuracy()
    {
        accuracy = hits / shotsFired *100;
    }

    public void Starsystem()
    {
            StarCalculation();
            Debug.Log("Accuracy = " + accuracy);
            Debug.LogError("Total Shots " + shotsFired);
    }

    public void StarCalculation()
    {
        Debug.LogError(score + " This is ePoints");
        if (accuracy >= 79 && score >= 3999 && greenDeaths >= 4)
            Debug.Log("5 star rating");
        else if (accuracy >= 59 && score >= 2999 && greenDeaths >= 3)
            Debug.Log("4 star rating");
        else if (accuracy >= 39 && score >= 1999 && greenDeaths >= 2)
            Debug.Log("3 star rating");
        else if (accuracy >= 19 && score >= 999 && greenDeaths >= 1)
            Debug.Log("2 star rating");
        else
            Debug.Log("1 star rating");
        
    }
}

