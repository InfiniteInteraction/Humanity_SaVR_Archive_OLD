using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public StartMenuFunctionality sMU;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        
        if((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.name.Equals("PlayButton"))
        {
            sMU.NewGame();
        }
        if ((other.tag == "RedBullet" || other.tag == "GreenBullet") && gameObject.name.Equals("CreditsButton"))
        {
            sMU.Credits();
        }
    }
}
