using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Paddle paddleR;
    public Paddle paddleL;
    public Ball ball;
    public Goal goalL;
    public Goal goalR;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("PaddleR") != 0)
        {
            paddleR.transform.Translate(Vector3.forward * Input.GetAxis("PaddleR"), Space.World);
        }
        if (Input.GetAxis("PaddleL") != 0)
        {
            paddleL.transform.Translate(Vector3.forward * Input.GetAxis("PaddleL"), Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.transform.position = new Vector3(0f, 0.5f, 0f);
            ball.Restart();
            paddleR.transform.position = new Vector3(25, 0.5f, 0f);
            paddleL.transform.position = new Vector3(-25, 0.5f, 0f);
            goalL.Restart();
            goalR.Restart();
        }
    }
}
