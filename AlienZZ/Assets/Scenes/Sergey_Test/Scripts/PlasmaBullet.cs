using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    GunTest gtScript;
    GunTestVR gtScriptVR;
    Quaternion camRot;
    bool collided = false;

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
        if (FindObjectOfType<CameraMovement>())
            camRot = FindObjectOfType<CameraMovement>().gameObject.transform.rotation;
    }
    private void Start()
    {
        if (gtScript)
            transform.rotation = camRot * Quaternion.Euler(0, 90, 0);
    }

    private void FixedUpdate()
    {
        if (!collided)
        {
            BulletGo();
        }
        else
        {
            StartCoroutine("AfterCollision");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer.Equals("Alien"))
        {
            if (gtScript)
                collision.collider.GetComponent<Health>().TakeDamage(gtScript.damageValue);
            if (gtScriptVR)
                collision.collider.GetComponent<Health>().TakeDamage(gtScriptVR.damageValue);
            collided = true;
        }
    }

    void BulletGo()
    {
        transform.position += transform.TransformDirection(Vector3.left) * 0.5f;
        StartCoroutine("Countdown");
    }

    IEnumerator AfterCollision()
    {
        if (tag.Equals("GreenBullet"))
        {
            GameObject splash = Resources.Load(("Prefabs/GreenSplashEffect"), typeof(GameObject)) as GameObject;
            Instantiate(splash, gameObject.transform);
        }
        else
        {
            GameObject splash = Resources.Load(("Prefabs/RedSplashEffect"), typeof(GameObject)) as GameObject;
            Instantiate(splash, gameObject.transform);
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("COLLISION");
        Destroy(gameObject);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}