using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombSpawnIntervalMin, bombSpawnIntervalMax, bombSpeed;
    private float nextSpawnTime;
    Transform bombFactory;
    void Start()
    {
        AlienFactory.incrementAlienCount(1);
        bombFactory = this.transform.Find("BombFactory");
        nextSpawnTime = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            nextSpawnTime += Random.Range(bombSpawnIntervalMin, bombSpawnIntervalMax);
            GameObject bomb = Instantiate(bombPrefab, bombFactory);
            bomb.GetComponent<Rigidbody>().velocity = Vector3.down * bombSpeed;
        }
    }

    public void Die()
    {
        AlienFactory.incrementAlienCount(-1);
    }
}
