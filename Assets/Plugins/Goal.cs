using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Ball ball;
    public Text scoreL;
    public Text scoreR;
    public int scoreN;
    public bool gameover = false;
    private AudioSource audioSource;
    public AudioClip goalCollision;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(goalCollision);
        if (this.name == "GoalL")
        {
            scoreN = int.Parse(scoreR.text);
            scoreN += 1;
            scoreR.text = scoreN.ToString();
            Debug.Log($"Right Player Scores! The score is now {scoreL.text} - {scoreR.text}");
            if (scoreR.text == "11")
            {
                Debug.Log("Right Player Wins! Game Over. Press Space to start a new game.");
                gameover = true;

            }
        }

        if (this.name == "GoalR")
        {
            scoreN = int.Parse(scoreL.text);
            scoreN += 1;
            scoreL.text = scoreN.ToString();
            Debug.Log($"Left Player Scores! The score is now {scoreL.text} - {scoreR.text}");
            if (scoreL.text == "11")
            {
                Debug.Log("Left Player Wins! Game Over. Press Space to start a new game.");
                gameover = true;

            }
        }

        if (gameover == false)
        {
            ball.transform.position = new Vector3(0f, 0.5f, 0f);
            ball.Restart();
        }
        

    }
    public void Restart()
    {
        scoreN = 0;
        scoreR.text = scoreN.ToString();
        scoreL.text = scoreN.ToString();
    }
}
