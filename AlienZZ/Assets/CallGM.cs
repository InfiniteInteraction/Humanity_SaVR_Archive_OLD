using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGM : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
         
    }
    private void Update()
    {
       gameManager.StarCalculation();
    }
}
