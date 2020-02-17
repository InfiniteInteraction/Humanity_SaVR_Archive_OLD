using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour
{
    public StartMenuFunctionality sMU;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
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
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("ResumeButton"))
        {
            panel.SetActive(false);
            
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.tag == ("PauseQuitButton"))
        {
            SceneManager.LoadScene(0); ;
        }

    }
}
