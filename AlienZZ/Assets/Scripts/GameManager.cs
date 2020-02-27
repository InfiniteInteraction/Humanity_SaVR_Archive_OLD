using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

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
    public float eSpeed = 3.5f;

    #endregion

    // private varibles not access by other classes
    #region Private 
    public int score;
    private float misses;
    string sceneName;
    #endregion

    public GameObject[] stars;
    public GameObject resultsBackground;
    
    private void Awake()
    {
        gameManager = this;
        levelOver = false;
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        stars[3].SetActive(false);
        stars[4].SetActive(false);
        
        resultsBackground.SetActive(false);

        DontDestroyOnLoad(this.gameObject);        
    }

    public void PlayButtonReturn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    }

    public void StarCalculation()
    {
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
    public void DifficultySetting()
    {
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Onslaught1": 
                break;
            case "Onslaught2":
                break;
            case "Onslaught3":
                break;
            case "Onslaught4":
                break;
            case "Onslaught5":
                break;
            case "Onslaught6":
                break;
            case "Onslaught7":
                break;
            case "Onslaught8":
                break;
            case "Onslaught9":
                break;
            case "Onslaught10":
                break;
        }
    }
}
    

       


