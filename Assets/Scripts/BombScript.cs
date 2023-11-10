using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float yLimit;
    public GameObject soundGenerator;
    public AudioClip collideSound;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < yLimit)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
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
        Destroy(gameObject);
    }
}
