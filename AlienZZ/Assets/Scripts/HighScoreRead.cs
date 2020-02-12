using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreRead : MonoBehaviour
{
    public Text highScoreRead = null;
    public Text highScoreRead2 = null;
    public Text highScoreRead3 = null;
    public ScoreManager sM;

    private void Start()
    {
        highScoreRead3.text = "HighScore: " + sM._highScores[2].ToString();
        highScoreRead.text = "HighScore: " + sM._highScores[3].ToString();
        highScoreRead2.text = "HighScore: " + sM._highScores[4].ToString();
    }
    private void Update()
    {
        highScoreRead3.text = "HighScore: " + sM._highScores[2].ToString();
        highScoreRead.text = "HighScore: " + sM._highScores[3].ToString();
        highScoreRead2.text = "HighScore: " + sM._highScores[4].ToString();
    }
}
