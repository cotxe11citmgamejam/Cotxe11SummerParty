using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBox : MonoBehaviour
{
    public GameObject box_usable;
    public GameObject box_broken;

    void Start()
    {
        box_usable.SetActive(true);
        box_broken.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        box_usable.SetActive(false);
        box_broken.SetActive(true);
    }
}
