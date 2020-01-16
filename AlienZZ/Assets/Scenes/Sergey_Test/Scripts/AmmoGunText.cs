using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGunText : MonoBehaviour
{
    GunTestVR gtScriptVR;
    Material numMat;

    private void Awake()
    {
        gtScriptVR = FindObjectOfType<GunTestVR>();
        numMat = GetComponent<Renderer>().material;
    }
    private void FixedUpdate()
    {
        int ag = gtScriptVR.currAmmo;
        int ag1 = ag / 100;
        int ag1to2 = ag - ag1 * 100;
        int ag2 = ag1to2 / 10;
        int ag3 = ag % 10;
        
        if(name.Equals("Digit1"))
        {
            numMat = Resources.Load(("Materials/Nums/" + ag1), typeof(Material)) as Material;
        }
        if (name.Equals("Digit2"))
        {
            numMat = Resources.Load(("Materials/Nums/" + ag2), typeof(Material)) as Material;
        }
        if (name.Equals("Digit3"))
        {
            numMat = Resources.Load(("Materials/Nums/" + ag3), typeof(Material)) as Material;
        }
        GetComponent<Renderer>().material = numMat;
    }
}
