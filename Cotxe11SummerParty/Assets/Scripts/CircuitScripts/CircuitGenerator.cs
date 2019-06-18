using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitGenerator : MonoBehaviour
{

    public GameObject circuitPart;
    public GameObject spawnPoint;
    public Transform nextCircuitPoint;

    private bool startDestroying = false;
    private float destroyingTempo = 0.0f;

    void Start()
    {
        float newRandPosToObjectSpawners = Random.RandomRange(-5, 5);
        spawnPoint.GetComponent<Transform>().position = new Vector3 (newRandPosToObjectSpawners, spawnPoint.GetComponent<Transform>().position.y, spawnPoint.GetComponent<Transform>().position.z);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            print("chock");
            GenerateNewPart();
        }
	}

    void GenerateNewPart()
    {
        GameObject nextOne = Instantiate(circuitPart, nextCircuitPoint.position , Quaternion.identity);
        startDestroying = true;
    }
}
