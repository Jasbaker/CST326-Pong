using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;


    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, 0f, speed * sz);

    }

    public void Restart()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, 0f, speed * sz);

    }


}
