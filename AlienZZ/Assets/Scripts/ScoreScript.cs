using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    Text score;

    public void Awake()
    {
        score = GetComponent<Text>();
        
    }
    public void Update()
    {
        score.text = "Score: " + scoreManager.currScore ;
       
    }
    public void Multi()
    {
        if ( scoreManager.currScore >= 600 && scoreManager.currScore <= 8000)
        {
            scoreManager.currScore += 200;
            
        }
        else if(scoreManager.currScore <= 599)
        {
            scoreManager.currScore += 100;
            
        }
        else if(scoreManager.currScore >= 8000)
        {
            scoreManager.currScore += 500;
           
        }
       
    }
}