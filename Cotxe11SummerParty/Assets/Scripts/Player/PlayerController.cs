using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float angular_speed = 5.0f;

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
            Vector3 new_pos = transform.position;
            new_pos.x = transform.position.x + speed * Time.deltaTime;
            transform.SetPositionAndRotation(new_pos, transform.rotation);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 new_pos = transform.position;
            new_pos.x = transform.position.x - speed * Time.deltaTime;
            transform.SetPositionAndRotation(new_pos, transform.rotation);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 new_pos = transform.position;
            new_pos.z = transform.position.z + speed * Time.deltaTime;
            transform.SetPositionAndRotation(new_pos, transform.rotation);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 new_pos = transform.position;
            new_pos.z = transform.position.z - speed * Time.deltaTime;
            transform.SetPositionAndRotation(new_pos, transform.rotation);
        }
    }
}
