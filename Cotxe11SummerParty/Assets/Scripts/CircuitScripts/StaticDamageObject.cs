using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDamageObject : MonoBehaviour
{
    private GameObject player;
    private bool hitted = false;
    private GameObject a_source;
    public AudioClip hit_01;

    void Start()
    {
        a_source = GameObject.Find("Global");
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
                a_source.GetComponent<AudioSource>().PlayOneShot(hit_01);
                collision.gameObject.GetComponent<PlayerStats>().LoseHP();
                hitted = true;
            }
        }
    }
}
