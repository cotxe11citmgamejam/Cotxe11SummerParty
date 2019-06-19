using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamera : MonoBehaviour
{

    public GameObject cotxe;

    public float radius = 1.0f;
    public float rotate_speed = 5.0f;
    public float height = 10.1f;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += rotate_speed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(angle) * radius, height, Mathf.Cos(angle) * radius);
        transform.position = cotxe.transform.position + offset;



        this.transform.LookAt(cotxe.transform);
    }
}
