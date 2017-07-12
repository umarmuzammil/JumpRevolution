using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {

    public int speed = 2;

    void Update () {

        Vector3 velocity = Vector3.left * speed * Time.deltaTime;
        transform.Translate(velocity);

        if (transform.position.x <= -(GameController.halfScreenSize+5))
            Destroy(transform.gameObject);
    }
}
