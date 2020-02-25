using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject[] stars;
    public GameObject resultsBackground;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        gameManager = this;
        levelOver = false;

        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        stars[3].SetActive(false);
        stars[4].SetActive(false);

        resultsBackground.SetActive(false);
    }

    public void PlayButtonReturn()
    {
        SceneManager.LoadScene(2);
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
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            stars[4].SetActive(true);
            Debug.Log("5 star rating");

        }        
        else if (accuracy >= 59 && score >= 2999 && greenDeaths >= 3)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            Debug.Log("4 star rating");

        }
        else if (accuracy >= 39 && score >= 1999 && greenDeaths >= 2)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            Debug.Log("3 star rating");

        }
        else if (accuracy >= 19 && score >= 999 && greenDeaths >= 1)
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            Debug.Log("2 star rating");

        }
        else
        {
            resultsBackground.SetActive(true);
            stars[0].SetActive(true);
            Debug.Log("1 star rating");

        }
    }
}

