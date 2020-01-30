using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    GunTestVR gtScript;
    UI_Info uiScript;
    private void Awake()
    {
        gtScript = FindObjectOfType<GunTestVR>();
        uiScript = FindObjectOfType<UI_Info>();
        currHealth = 1f;
    }

    private void Update()
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
            currHealth -= gtScript.damageValue;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("RedBullet") || other.gameObject.tag == "GreenBullet")
    //    {
    //        currHealth -= gtScript.damageValue;
    //    }
    //}
}
