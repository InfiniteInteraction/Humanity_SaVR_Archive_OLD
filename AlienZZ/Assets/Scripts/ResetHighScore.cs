using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetHighScore : MonoBehaviour
{
    public ScoreManager sM;
    public void ResetScores()
    {
        sM.ResetAllHighScores();
        sM.Save();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("ResetButton"))
        {
            ResetScores();
        }
    }
   
}
