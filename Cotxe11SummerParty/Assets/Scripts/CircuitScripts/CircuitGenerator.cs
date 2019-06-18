using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitGenerator : MonoBehaviour
{
    // Internal
    public GameObject circuitPart;
    public GameObject spawnPoint;
    public Transform nextCircuitPoint;

    // External
    public GameObject emptyBox;
    public GameObject bomb;
    
    // Internal Variables
    private bool startDestroying = false;
    private float destroyingTempo = 0.0f;
    private float throwItemTempo = 5.0f;

    public float timeToThrowAnItem = 5.0f;
    public float timeToKillAnItem = 10.0f;

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

        throwItemTempo += Time.deltaTime;
        if (throwItemTempo > timeToThrowAnItem)
        {
            float newRandPosToObjectSpawners = Random.RandomRange(-5, 5);
            spawnPoint.GetComponent<Transform>().position = new Vector3(newRandPosToObjectSpawners, spawnPoint.GetComponent<Transform>().position.y, spawnPoint.GetComponent<Transform>().position.z);
            ThrowAnItem();
            throwItemTempo = 0.0f;
        }
    }

	void OnTriggerEnter(Collider collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            GenerateNewPart();
        }
	}

    void GenerateNewPart()
    {
        GameObject nextOne = Instantiate(circuitPart, nextCircuitPoint.position , Quaternion.identity); // Genera una nova peça del circuit
        startDestroying = true;
    }

    void ThrowAnItem()
    {
        int itemNum = Random.RandomRange(0,2); // Numero total d'items
        switch (itemNum)
        {
            case 0: 
                GameObject itemThrown = Instantiate(emptyBox, spawnPoint.transform.position, Quaternion.identity);
                Destroy(itemThrown, timeToKillAnItem);
                break;
            case 1:
                GameObject itemThrown2 = Instantiate(bomb, spawnPoint.transform.position, Quaternion.identity);
                Destroy(itemThrown2, timeToKillAnItem);
                break;
        }
    }
}
