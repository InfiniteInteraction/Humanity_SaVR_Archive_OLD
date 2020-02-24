using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadHP : MonoBehaviour
{
    public TextMeshProUGUI hP;
    public TextMeshProUGUI aC;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        aC.text = "Accuracy: " + GameObject.FindObjectOfType<GameManager>().accuracy.ToString();
       hP.text = "Health: " + GameObject.FindObjectOfType<Damage>().playerHealth.ToString();
    }
}
