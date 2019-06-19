using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float boxSpeed = 1.0f;
    GameObject source;
    public AudioClip explosion;

    void Start()
    {
        source = GameObject.Find("Global");
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, boxSpeed));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.GetComponent<AudioSource>().PlayOneShot(explosion);
            other.gameObject.GetComponent<PlayerStats>().LoseHP();
        }
    }
}
