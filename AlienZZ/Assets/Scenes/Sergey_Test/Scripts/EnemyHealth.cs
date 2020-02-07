using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    GunTestVR gtScript;
    UI_Info uiScript;
    public ScoreScript scoreS;
    public ESpawner spawn;
    private void Awake()
    {
        gtScript = FindObjectOfType<GunTestVR>();
        uiScript = FindObjectOfType<UI_Info>();
        currHealth = 3;
        scoreS = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ESpawner>();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);

        if (currHealth <= 0)
        {
            uiScript.alienCount++;
            scoreS.Multi();
            spawn.SpawnEnemy();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("RedBullet") || collision.collider.tag == "GreenBullet")
            //currHealth -= gtScript.damageValue;
        TakeDamage(gtScript.damageValue);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("RedBullet") || other.gameObject.tag == "GreenBullet")
    //    {
    //        currHealth -= gtScript.damageValue;
    //    }
    //}

}
