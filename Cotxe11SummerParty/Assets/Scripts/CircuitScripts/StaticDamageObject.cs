using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDamageObject : MonoBehaviour
{
    private GameObject player;

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
            collision.gameObject.GetComponent<PlayerStats>().HP--;
        }
    }
}
