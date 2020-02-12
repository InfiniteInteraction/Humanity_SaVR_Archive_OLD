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
    void OnTriggerEnter()
    {
        if(gameObject.tag == "RedBullet")
        {
            sMU.NewGame();
        }
    }
}
