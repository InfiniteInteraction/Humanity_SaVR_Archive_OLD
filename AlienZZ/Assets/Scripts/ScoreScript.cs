using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
  public int scoreValue = 0;
  Text score;

    public void Awake()
    {
        score = GetComponent<Text>();
    }
    public void Update()
    {
        score.text = "Score: " + scoreValue;
       
    }
    public void Multi()
    {
        if (scoreValue >= 200 && scoreValue <= 800)
        {
            scoreValue += 20;
        }
        else if(scoreValue <= 199)
        {
            scoreValue += 10;
        }
        else if(scoreValue>= 800)
        {
            scoreValue += 300;
        }
       
    }
}