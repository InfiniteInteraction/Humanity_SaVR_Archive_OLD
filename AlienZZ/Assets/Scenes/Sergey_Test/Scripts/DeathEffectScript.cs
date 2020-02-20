using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectScript : MonoBehaviour
{
    public float alphaMinus = 0;
    Color psColor;

    private void Awake()
    {
        psColor.a = 0.9f;
        StartCoroutine("Destroy");
    }
    private void FixedUpdate()
    {
        alphaMinus += Time.fixedDeltaTime * 50;
        psColor.a -= alphaMinus;
        //DeathEffect();
    }

    void DeathEffect()
    {
        Material mat = GetComponent<Material>();
        mat.color = psColor;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
