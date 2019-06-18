using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBox : MonoBehaviour
{
    public GameObject box_usable;
    public GameObject box_broken;
    public float boxSpeed = 0.5f;

    private int random_number = 0;

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
            random_number = Random.Range(1,2);
            if (random_number == 1)
            {
                if (other.gameObject.GetComponent<PlayerStats>().controlls_inverted == false)
                {
                    other.gameObject.GetComponent<PlayerStats>().InvertControlls();
                }
                else
                {
                    other.gameObject.GetComponent<PlayerStats>().timer_inverted_controlls = 0.0f;
                }
            }
            else
            {
                if (other.gameObject.GetComponent<PlayerStats>().speed_increased == false)
                {
                    other.gameObject.GetComponent<PlayerStats>().GiveExtraSpeed();
                }
                else
                {
                    other.gameObject.GetComponent<PlayerStats>().timer_extra_speed = 0.0f;
                }
            }
        }
    }
}