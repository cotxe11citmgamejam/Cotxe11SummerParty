using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int HP = 3;
    public float time_controlls_inverted = 5.0f;

    [HideInInspector]
    public bool controlls_inverted = false;
    private float timer_inverted_controlls = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer_inverted_controlls = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlls_inverted == true)
        {
            timer_inverted_controlls += Time.deltaTime;
            if (timer_inverted_controlls >= time_controlls_inverted)
            {
                InvertControlls();
            }
        }
    }

    public void InvertControlls()
    {
        if (gameObject.GetComponent<PlayerController>().key_left == "a")
        {
            gameObject.GetComponent<PlayerController>().key_left = "d";
            gameObject.GetComponent<PlayerController>().key_right = "a";
            controlls_inverted = true;
            timer_inverted_controlls = 0.0f;
        }
        else
        {
            gameObject.GetComponent<PlayerController>().key_left = "a";
            gameObject.GetComponent<PlayerController>().key_right = "d";
            controlls_inverted = false;
            timer_inverted_controlls = 0.0f;
        }
    }

}
