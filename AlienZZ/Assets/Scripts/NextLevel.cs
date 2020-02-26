using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Scene scene;
    public static bool gamePaused = false;
    public GameObject pausemenuUI;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();            
            }
        }
    }
       public void Resume()
      {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
      }
       public void Pause()
       {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
       }
    public void Next()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        ScoreManager.scoreManager.Save();
        Time.timeScale = 1f;
        gamePaused = false;
        SceneManager.LoadScene(0);
    }
}
