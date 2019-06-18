using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float angular_speed = 0.5f;

    public float left_max_angle = -45.0f;
    public float right_max_angle = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 new_pos = transform.localPosition;
            new_pos.x = new_pos.x + speed * Time.deltaTime;
            transform.SetPositionAndRotation(new_pos, transform.rotation);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 new_pos = transform.localPosition;
            new_pos.x = new_pos.x - speed * Time.deltaTime;
            transform.SetPositionAndRotation(new_pos, transform.rotation);
        }
        if (Input.GetKey(KeyCode.A))
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
        if (Input.GetKey(KeyCode.D))
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
