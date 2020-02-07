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
        SceneManager.LoadScene(5);
    }
   public void Quit()
    {
        Application.Quit();
    }
}
