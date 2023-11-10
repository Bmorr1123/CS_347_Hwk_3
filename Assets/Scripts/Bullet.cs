using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float yLimit;
    public GameObject soundGenerator;
    public AudioClip collideSound;
    // Start is called before the first frame update
    void Start()
    {
        Shooting.IncrementBulletCount(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > yLimit)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject sg = Instantiate(soundGenerator);
            AudioSource audioSource = sg.GetComponent<AudioSource>();
            audioSource.clip = collideSound;
            audioSource.Play();
            Die();
        }
    }

    void Die()
    {
        Shooting.IncrementBulletCount(-1);
        Destroy(gameObject);
    }
}
