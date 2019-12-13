using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, 0.1f);
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
