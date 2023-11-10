using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombSpawnIntervalMin, bombSpawnIntervalMax, bombSpeed;
    private float nextSpawnTime;
    public Transform bombFactory;
    void Start()
    {
        AlienFactory.incrementAlienCount(1);
        nextSpawnTime = Time.timeSinceLevelLoad + Random.Range(bombSpawnIntervalMin, bombSpawnIntervalMax);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            print("HERE");
            nextSpawnTime += Random.Range(bombSpawnIntervalMin, bombSpawnIntervalMax);
            GameObject bomb = Instantiate(bombPrefab, bombFactory.position, bombFactory.rotation);
            bomb.GetComponent<Rigidbody>().velocity = Vector3.down * bombSpeed;
        }
    }

    public void Die()
    {
        AlienFactory.incrementAlienCount(-1);
    }
}
