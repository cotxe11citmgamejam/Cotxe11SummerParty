using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float boxSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, boxSpeed));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().LoseHP();
        }
    }
}
