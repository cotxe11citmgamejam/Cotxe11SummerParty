using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDamageObject : MonoBehaviour
{
    private GameObject player;
    private bool hitted = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hitted == false)
            {
                collision.gameObject.GetComponent<PlayerStats>().HP--;
                hitted = true;
            }
        }
    }
}
