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
    public GameObject column1;
    public GameObject bridge1;

    // Internal Variables
    private bool startDestroying = false;
    private float destroyingTempo = 0.0f;
    private float throwItemTempo = 5.0f;

    public float timeToThrowAnItem = 2.5f;
    public float timeToKillAnItem = 10.0f;

    void Start()
    {
        int whatPut = Random.RandomRange(0, 2);
        switch(whatPut)
        {
            case 0: // Cas columna
                float randPosColumnX = Random.RandomRange(-4, 4);
                float randPosColumnY = Random.RandomRange(gameObject.transform.position.z - 10, gameObject.transform.position.z + 10);
                spawnPoint.GetComponent<Transform>().position = new Vector3(randPosColumnX, spawnPoint.GetComponent<Transform>().position.y, randPosColumnY);
                GameObject itemThrown = Instantiate(column1, spawnPoint.transform.position, Quaternion.identity);
                itemThrown.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 90));
                Destroy(itemThrown, timeToKillAnItem);
                break;
            case 1: // Cas bridge
                float randPosBridgeY = Random.RandomRange(gameObject.transform.position.z - 10, gameObject.transform.position.z + 10);
                spawnPoint.GetComponent<Transform>().position = new Vector3(spawnPoint.GetComponent<Transform>().position.x + 5, spawnPoint.GetComponent<Transform>().position.y, randPosBridgeY);
                GameObject itemThrown2 = Instantiate(bridge1, spawnPoint.transform.position, Quaternion.identity);
                itemThrown2.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 90));
                Destroy(itemThrown2, timeToKillAnItem);
                break;
            case 2: // Just nothing

                break;
            case 3:

                break;
        }
       
    }

    void Update()
    {
        if (startDestroying)
        {
            destroyingTempo += Time.deltaTime;
            if (destroyingTempo > 10)
            {
                Destroy(gameObject);
                spawnPoint.SetActive(false);
            }
        }

        throwItemTempo += Time.deltaTime;
        if (throwItemTempo > timeToThrowAnItem)
        {
            float newRandPosToObjectSpawners = Random.RandomRange(-5, 5);
            spawnPoint.GetComponent<Transform>().position = new Vector3(newRandPosToObjectSpawners, spawnPoint.GetComponent<Transform>().position.y, spawnPoint.GetComponent<Transform>().position.z - 17);
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
