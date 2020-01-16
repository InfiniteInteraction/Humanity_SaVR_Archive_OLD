using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoGunText : MonoBehaviour
{
    GunTestVR gtScriptVR;
    Text ammoGun;
    private void Awake()
    {
        gtScriptVR = FindObjectOfType<GunTestVR>();
        ammoGun = GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        int ag = gtScriptVR.currAmmo;
        ammoGun = ag.
    }
}
