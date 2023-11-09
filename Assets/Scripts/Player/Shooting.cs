using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Parameters")]
    public Transform cannonTransform;
    public GameObject bulletPrefab;
    public int maxNumBullets;
    public float bulletSpeed;
    public float minShootDelay;
    private float timeSinceLastShot;
    static int numBullets;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShot = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ProcessPlayerInput(bool playerShoot)
    {
        if (playerShoot && Time.timeSinceLevelLoad - timeSinceLastShot > minShootDelay && numBullets < maxNumBullets)
        {
            timeSinceLastShot = Time.timeSinceLevelLoad;

            GameObject bullet = Instantiate(bulletPrefab, cannonTransform.position, cannonTransform.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = Vector3.up * bulletSpeed;
        }
    }

    public static void IncrementBulletCount(int amount)
    {
        numBullets += amount;
    }
}
