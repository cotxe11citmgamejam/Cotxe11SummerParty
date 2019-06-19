using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float time2change_scene = 3.0f;
    private float timer2change_scene = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer2change_scene = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerStats>().dead == false) {
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
                if (new_rotation.y >= 90 + left_max_angle)
                {
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
            }
            if (Input.GetKey(key_right))
            {
                Vector3 new_rotation = new Vector3();
                new_rotation.y = transform.rotation.eulerAngles.y;
                if (new_rotation.y <= 90 + right_max_angle)
                {
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
        else
        {
            timer2change_scene += Time.deltaTime;
            transform.Translate(Vector3.down * 0.5f * Time.deltaTime);
            if (timer2change_scene >= time2change_scene)
            {
                PlayerPrefs.SetFloat("Distance", gameObject.GetComponent<PlayerStats>().distance_done);
                SceneManager.LoadScene("Finish");
            }
        }
    }
}
