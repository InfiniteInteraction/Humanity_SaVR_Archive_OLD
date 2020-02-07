using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetHighScore
{
  [MenuItem("HighScore/Reset Highscore")]

  public static void ResetHigh()
    {
        ScoreManager.ResetHighScore();
    }
}
