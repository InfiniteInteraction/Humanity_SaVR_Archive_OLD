using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int scoreValue = 0;
    public ScoreManager sM;
    Text score;

    public void Awake()
    {
        score = GetComponent<Text>();
        
    }
    public void Update()
    {
        score.text = "Score: " + scoreValue ;
       
    }
    public void Multi()
    {
        if (scoreValue >= 600 && scoreValue <= 8000)
        {
            scoreValue += 20;
            
        }
        else if(scoreValue <= 599)
        {
            scoreValue += 10;
            
        }
        else if(scoreValue>= 8000)
        {
            scoreValue += 500;
           
        }
       
    }
}