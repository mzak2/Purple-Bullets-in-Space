using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float yTop = 6;
    private float yBottom = -4;
    private float xLeft = 13;
    private float xRight = 15;
    private float startDelay = 3;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = Vector3.zero;

        {
            spawnPos = new Vector3(Random.Range(xLeft, xRight), Random.Range(yBottom, yTop), -2);
        }

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);    
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, Quaternion.identity);
    }
}
