using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour
{
    public StartMenuFunctionality sMU;
    public GameObject panel;

    void Start()
    {
        panel = null;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag ==("PlayButton"))
        {
            sMU.NewGame();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag ==("CreditsButton"))
        {
            sMU.Credits();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("QuitButton"))
        {
            sMU.ExitGame();
        }

        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelOne"))
        {
            sMU.LevelOne();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelTwo"))
        {
            sMU.LevelTwo();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelThree"))
        {
            sMU.LevelThree();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelFour"))
        {
            sMU.LevelFour();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelFive"))
        {
            sMU.LevelFive();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelSix"))
        {
            sMU.LevelSix();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelSeven"))
        {
            sMU.LevelSeven();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelEight"))
        {
            sMU.LevelEight();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelNine"))
        {
            sMU.LevelNine();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("LevelTen"))
        {
            sMU.LevelTen();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("ResumeButton"))
        {
            panel.SetActive(false);           
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("PauseQuitButton"))
        {
            Debug.Log("we should have saved");
            ScoreManager.scoreManager.Save();
            SceneManager.LoadScene(0);
        }

    }
}
