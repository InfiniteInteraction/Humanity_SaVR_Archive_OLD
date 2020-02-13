using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HighScoreRead : MonoBehaviour
{
    public TextMeshProUGUI highScoreRead = null;
    public TextMeshProUGUI highScoreRead2 = null;
    public TextMeshProUGUI highScoreRead3 = null;
    public ScoreManager sM;

    private void Start()
    {
        highScoreRead3.text = "HighScore: " + sM._highScores[4].ToString();
        highScoreRead.text = "HighScore: " + sM._highScores[2].ToString();
        highScoreRead2.text = "HighScore: " + sM._highScores[3].ToString();
    }
    private void Update()
    {
        highScoreRead3.text = "HighScore: " + sM._highScores[4].ToString();
        highScoreRead.text = "HighScore: " + sM._highScores[2].ToString();
        highScoreRead2.text = "HighScore: " + sM._highScores[3].ToString();
    }
}
