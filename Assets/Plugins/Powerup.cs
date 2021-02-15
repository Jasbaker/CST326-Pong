using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Ball ball;
    private float update;
    private bool inplay = false;
    private AudioSource audioSource;
    public AudioClip powerupCollision;

    void Awake()
    {
        update = Random.Range(1f, 10f);
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(powerupCollision);
        if (this.name == "PowerUpSpeed")
        {
            ball.speed = ball.speed * 2;
        }
        if (this.name == "PowerUpSize")
        {
            ball.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        this.transform.position = new Vector3(-19f, 0.5f, 22f);
        update = Random.Range(1f, 10f);
        inplay = false;

    }

    void Update()
    {
        update += 0.0015f;
        if (update > 25f & inplay == false)
        {
            this.transform.position = new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-12f, 12f));
            inplay = true;
            
        }

    }
}
