using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBox : MonoBehaviour
{
    public GameObject box_usable;
    public GameObject box_broken;
    public float boxSpeed = 0.5f;

    void Start()
    {
        box_usable.SetActive(true);
        box_broken.SetActive(false);
    }

    void Update()
    {
        transform.Translate(new Vector3(0,0,boxSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            box_usable.SetActive(false);
            box_broken.SetActive(true);
            if (other.gameObject.GetComponent<PlayerStats>().controlls_inverted == false)
            {
                other.gameObject.GetComponent<PlayerStats>().InvertControlls();
            }
        }
    }
}