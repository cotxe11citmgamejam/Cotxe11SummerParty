using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float z_distance = 5;
    public float y_distance = 10;
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_pos = new Vector3();
        new_pos.x = target.gameObject.transform.position.x;
        new_pos.y = target.gameObject.transform.position.y + y_distance;
        new_pos.z = target.gameObject.transform.position.z + z_distance;
        transform.SetPositionAndRotation(new_pos, transform.rotation);
    }
}
