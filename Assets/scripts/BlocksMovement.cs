using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksMovement : MonoBehaviour {

    int speed = 5; 


    void Move(string direction)
    {
        Vector3 velocity = Vector3.left * speed * Time.deltaTime;

        if (direction == "left")
        {
            transform.Translate(velocity);
        }
    }

    void Update () {
        Move("left");

    }
}
