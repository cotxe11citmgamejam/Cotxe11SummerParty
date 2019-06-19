using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersCollisions : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hit_02;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(hit_02);
            collision.gameObject.GetComponent<PlayerStats>().Die();
        }
    }

}
