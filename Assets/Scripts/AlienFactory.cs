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

    public float alienPeed;

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

        GameObject alien = Instantiate(alienPrefabs[Random.Range(0, alienPrefabs.Length)]);

        if (Random.value < 0.5)
        {  // Spawn to the left
            alien.transform.position = new Vector3(xMin, Random.Range(yMin, yMax), 0);

            // Flipping the ship horizontally
            Transform model = alien.transform.Find("Model");
            model.localScale = new Vector3(model.localScale.x, model.localScale.y, -model.localScale.z);
            alien.GetComponent<Rigidbody>().velocity = alienPeed * Vector3.right;
        }
        else
        {  // Spawn to the right
            alien.transform.position = new Vector3(xMax, Random.Range(yMin, yMax), 0);
            alien.GetComponent<Rigidbody>().velocity = alienPeed * Vector3.left;
        }

    }

    public static void incrementAlienCount(int incrementBy)
    {
        alienCount += incrementBy;
    }
}
