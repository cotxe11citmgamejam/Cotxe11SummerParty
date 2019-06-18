﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 20.0f;
    public float angular_speed = 5.0f;

    public float left_max_angle = -45.0f;
    public float right_max_angle = 45.0f;

    [HideInInspector]
    public string key_front = "w";
    [HideInInspector]
    public string key_back = "s";
    [HideInInspector]
    public string key_right = "d";
    [HideInInspector]
    public string key_left = "a";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(key_front))
       // {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(key_back))
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
        if (Input.GetKey(key_left))
        {
            Vector3 new_rotation = new Vector3();
            new_rotation.y = transform.rotation.eulerAngles.y;
            if (transform.rotation.eulerAngles.y > 0)
            {
                new_rotation.y = new_rotation.y - angular_speed * Time.deltaTime;
                new_rotation.Normalize();
                //new_rotation.y = -new_rotation.y;
                new_rotation *= -angular_speed;
                transform.Rotate(new_rotation);
            }
            else if (transform.rotation.eulerAngles.y <= 0 && transform.rotation.eulerAngles.y > left_max_angle)
            {
                new_rotation.y = new_rotation.y + angular_speed * Time.deltaTime;
                new_rotation.Normalize();
                //new_rotation.y = -new_rotation.y;
                new_rotation *= angular_speed;
                transform.Rotate(0.0f, 360.0f - new_rotation.y, 0.0f);
            }
        }
        if (Input.GetKey(key_right))
        {
            Vector3 new_rotation = new Vector3();
            new_rotation.y = transform.rotation.eulerAngles.y;
            //Vector3 new_rotation = transform.rotation.eulerAngles;
            if ((transform.rotation.eulerAngles.y < right_max_angle && transform.rotation.eulerAngles.y >= 0.0f) || transform.rotation.eulerAngles.y > right_max_angle)
            {
                new_rotation.y = new_rotation.y + angular_speed * Time.deltaTime;
                new_rotation.Normalize();
                new_rotation *= angular_speed;
                transform.Rotate(new_rotation);
            }
            else if (transform.rotation.eulerAngles.y < 0.0f)
            {
                new_rotation.y = new_rotation.y - angular_speed * Time.deltaTime;
                new_rotation.Normalize();
                new_rotation *= -angular_speed;
                transform.Rotate(new_rotation);
            }
        }
    }
}
