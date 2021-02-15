using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTag
{
    Paddle,
    Ball,
    Goal,
    Powerup,
    Wall
}

public class Ball : MonoBehaviour
{
    public float startSpeed;
    public float step;
    public float speed;
    private Rigidbody rb;
    public Goal goalL;
    public Goal goalR;
    private AudioSource audioSource;
    public AudioClip paddleCollision;


    void Start()
    {
        Restart();

    }

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = startSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    public void Restart()
    {
        speed = startSpeed;
        rb.MovePosition(Vector3.zero);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
        transform.localScale = new Vector3(1f, 1f, 1f);
        goalL.gameover = false;
        goalR.gameover = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            audioSource.PlayOneShot(paddleCollision);

            speed += step;
            float heightAboveOrBelow = transform.position.z - collision.transform.position.z;
            float maxHeight = collision.collider.bounds.extents.z;
            float percentOfMax = heightAboveOrBelow / maxHeight;

            bool hitLeftPaddle = collision.gameObject.name == "PaddleLeft";
            float newHorizontalSpeed = (hitLeftPaddle) ? speed : -speed;

            Vector3 newVelocity = new Vector3(newHorizontalSpeed, 0f, percentOfMax * 4f).normalized * speed;
            rb.velocity = newVelocity;
        }

    }
}
