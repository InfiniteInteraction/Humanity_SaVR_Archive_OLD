using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    GunTest gtScript;
    Quaternion camRot;

    private void Awake()
    {
        gtScript = FindObjectOfType<GunTest>();
        camRot = FindObjectOfType<CameraMovement>().gameObject.transform.rotation;
    }
    private void Start()
    {
        transform.rotation = camRot * Quaternion.Euler(0, 90, 0);
        //transform.rotation = transform.rotation * Quaternion.Euler(0, 90, 0);
    }
    void Update()
    {
        transform.position = transform.position + transform.TransformDirection(Vector3.left) / 2;
        StartCoroutine("Countdown");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer.Equals("Alien"))
        {
            collision.collider.GetComponent<Health>().TakeDamage(gtScript.damageValue);
        }
        Destroy(gameObject);
        Debug.Log("COLLISION");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer.Equals("Alien"))
    //    {
    //        other.gameObject.GetComponent<Health>().TakeDamage(gtScript.damageValue);
    //    }
    //    Destroy(gameObject);
    //    Debug.Log("TRIGGER");
    //}

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
