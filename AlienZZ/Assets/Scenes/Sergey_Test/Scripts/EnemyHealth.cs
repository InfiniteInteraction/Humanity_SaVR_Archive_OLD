using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    GunTest gtScript;
    GunTestVR gtScriptVR;
    UI_Info uiScript;
    private void Awake()
    {
        if (FindObjectOfType<GunTest>())
        {
            gtScript = FindObjectOfType<GunTest>();
            gtScriptVR = null;
        }
        if (FindObjectOfType<GunTestVR>())
        {
            gtScriptVR = FindObjectOfType<GunTestVR>();
            gtScript = null;
        }
        uiScript = FindObjectOfType<UI_Info>();
        currHealth = 1f;
    }

    private void FixedUpdate()
    {
        if (currHealth <= 0)
        {
            uiScript.alienCount++;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("RedBullet") || collision.collider.tag == "GreenBullet")
        {
            if (gtScript)
                currHealth -= gtScript.damageValue;
            if (gtScriptVR)
                currHealth -= gtScriptVR.damageValue;
        }
    }
}
