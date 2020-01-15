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

}