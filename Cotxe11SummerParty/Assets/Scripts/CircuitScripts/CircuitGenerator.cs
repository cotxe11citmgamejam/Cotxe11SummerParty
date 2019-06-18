using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitGenerator : MonoBehaviour
{

    public GameObject circuitPart;
    public Transform nextCircuitPoint;

    private bool startDestroying = false;
    private float destroyingTempo = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (startDestroying)
        {
            destroyingTempo += Time.deltaTime;
            if (destroyingTempo > 10)
                Destroy(gameObject);
        }
    }

	void OnTriggerEnter(Collider collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            GenerateNewPart();
        }
	}

    void GenerateNewPart()
    {
        GameObject nextOne = Instantiate(circuitPart, nextCircuitPoint.position , Quaternion.identity);
        startDestroying = true;
    }
}
