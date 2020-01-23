using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_ChangeMat : MonoBehaviour
{
    GunTestVR gtScript;

    private void Awake()
    {
        gtScript = FindObjectOfType<GunTestVR>();
    }

    private void Start()
    {
        gtScript.emissiveObjects.Add(gameObject);
    }
}
