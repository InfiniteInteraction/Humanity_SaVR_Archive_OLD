using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Info : MonoBehaviour
{
    GunTest gtScript;
    string text, fireMode;
    Text myText;
    public int ammo, alienCount;
    float deltaTime = 0f;

    private void Awake()
    {
        gtScript = FindObjectOfType<GunTest>();
        myText = GetComponent<Text>();
        fireMode = " ";
        alienCount = 0;
    }

    private void FixedUpdate()
    {
        if (gtScript.fullAutoMode)
            fireMode = "AUTO";
        else
            fireMode = "SINGLE";
        deltaTime = Time.frameCount / Time.time;
        ammo = gtScript.currAmmo;
        text = ("Ammo: " + ammo + "\n" + "Firing mode: " + fireMode + "\n" + "Alien Count: " + alienCount + "\n" + "FPS: " + deltaTime);
        myText.text = text;
    }

}
