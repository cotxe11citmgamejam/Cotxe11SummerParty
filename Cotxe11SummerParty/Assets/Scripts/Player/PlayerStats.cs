using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int HP = 3;
    public float time_controlls_inverted = 5.0f;
    public float time_extra_speed = 5.0f;

    public float extra_speed = 10.0f;
    public float extra_angular_speed = 10.0f;

    [HideInInspector]
    public bool controlls_inverted = false;
    [HideInInspector]
    public bool speed_increased = false;
    [HideInInspector]
    public float timer_inverted_controlls = 0.0f;
    [HideInInspector]
    public float timer_extra_speed = 0.0f;

    private float original_speed = 5.0f;
    private float original_angular_speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer_inverted_controlls = 0.0f;
        timer_extra_speed = 0.0f;
        original_speed = gameObject.GetComponent<PlayerController>().speed;
        original_angular_speed = gameObject.GetComponent<PlayerController>().angular_speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Invert Controlls
        if (controlls_inverted == true)
        {
            timer_inverted_controlls += Time.deltaTime;
            if (timer_inverted_controlls >= time_controlls_inverted)
            {
                InvertControlls();
            }
        }
        //Extra Speed
        if (speed_increased == true)
        {
            timer_extra_speed += Time.deltaTime;
            if (timer_extra_speed >= time_extra_speed)
            {
                ResetSpeed();
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

    public void ResetSpeed()
    {
        gameObject.GetComponent<PlayerController>().speed = original_speed;
        gameObject.GetComponent<PlayerController>().angular_speed = original_angular_speed;
        speed_increased = false;
        timer_extra_speed = 0.0f;
    }

    public void GiveExtraSpeed()
    {
        gameObject.GetComponent<PlayerController>().speed = extra_speed;
        gameObject.GetComponent<PlayerController>().angular_speed = extra_angular_speed;
        speed_increased = true;
        timer_extra_speed = 0.0f;
    }

}
