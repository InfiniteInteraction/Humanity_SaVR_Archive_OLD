using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject manager;


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    private  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
