using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    GunTest gtScript;
    GunTestVR gtScriptVR;
    Quaternion camRot;
    Quaternion gunRot;

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
        if(FindObjectOfType<CameraMovement>())
            camRot = FindObjectOfType<CameraMovement>().gameObject.transform.rotation;
        if(FindObjectOfType<ID_BulletSpawnVR>())
            camRot = FindObjectOfType<ID_BulletSpawnVR>().gameObject.transform.rotation;
    }
    private void Start()
    {
        //transform.rotation = camRot * Quaternion.Euler(0, 90, 0);
        transform.rotation = gunRot * Quaternion.Euler(0, 90, 0);
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + transform.TransformDirection(Vector3.left);
        StartCoroutine("Countdown");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer.Equals("Alien"))
        {
            if(gtScript)
            collision.collider.GetComponent<Health>().TakeDamage(gtScript.damageValue);
            if(gtScriptVR)
            collision.collider.GetComponent<Health>().TakeDamage(gtScriptVR.damageValue);
        }
        Destroy(gameObject);
        Debug.Log("COLLISION");
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
