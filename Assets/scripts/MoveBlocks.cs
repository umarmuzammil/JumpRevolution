using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {

    public int speed = 5;

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
        if (transform.position.x <= -GameController.halfScreenSize)
            Destroy(transform.gameObject);
    }

    void Update () {
		
        MoveIt("left");
        DestroyIt();
        
   

    }
}
