using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public Goal goalL;
    public Goal goalR;


    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, 0.5f, speed * sz);

    }

    public void Restart()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, 0.5f, speed * sz);
        goalL.gameover = false;
        goalR.gameover = false;

    }


}
