using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayerInfo : MonoBehaviour
{

    private float distance = 0.0f;
    public Text distance_text;

    // Start is called before the first frame update
    void Start()
    {
        distance = PlayerPrefs.GetFloat("Distance", 0);
        distance_text.text = distance.ToString("F0") + "m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
