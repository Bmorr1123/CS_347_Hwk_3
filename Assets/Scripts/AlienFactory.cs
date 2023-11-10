using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFactory : MonoBehaviour
{
    public GameObject[] alienPrefabs;
    public int maxAlienCount;
    public float spawnInterval;
    private static int alienCount;  // static so that we don't need to use references
    private float nextSpawnTime;

    public float xMin = -25f, xMax = 25f, yMin = 25f, yMax = 25f;

    void Start()
    {
        nextSpawnTime = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            nextSpawnTime = Time.timeSinceLevelLoad + spawnInterval;
            if (alienCount < maxAlienCount)
            {
                spawnAlien();
            }
        }
    }

    void spawnAlien()
    {

        Vector3 spawnPos;
        bool spawnedLeft;
        if (Random.value < 0.5)
        {  // Spawn to the left
            spawnedLeft = true;
            spawnPos = new Vector3(xMin, Random.Range(yMin, yMax), 0);
        }
        else
        {  // Spawn to the right
            spawnedLeft = false;
            spawnPos = new Vector3(xMax, Random.Range(yMin, yMax), 0);
        }

        GameObject alien = Instantiate(alienPrefabs[Random.Range(0, alienPrefabs.Length)]);
        alien.transform.position = spawnPos;
        if (spawnedLeft)  // Flipping the ship horizontally
        {
            alien.transform.localScale = new Vector3(-alien.transform.localScale.x, alien.transform.localScale.y, alien.transform.localScale.z);
            print(alien.transform.localScale);
        }
    }

    public static void incrementAlienCount(int incrementBy)
    {
        alienCount += incrementBy;
    }
}
