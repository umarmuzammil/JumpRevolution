using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksMovement : MonoBehaviour {

    float halfScreenSize;

    public int speed = 5;

    void Start()
    {
        halfScreenSize = Camera.main.orthographicSize * Camera.main.aspect;
        Debug.Log(halfScreenSize);
    }

    void MoveIt(string direction)
    {
        Vector3 velocity = Vector3.left * speed * Time.deltaTime;

        if (direction == "left")
        {
            transform.Translate(velocity);
        }
    }

    void DestroyIt()
    {
        if (transform.position.x <= -halfScreenSize)
            Destroy(transform.gameObject);
    }

    void Update () {
        MoveIt("left");
        DestroyIt();

    }
}
