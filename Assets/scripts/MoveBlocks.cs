using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {

    public static int speed = 3;
    private bool paused = false;

    void Pause(bool state)
    {
        paused = state;
    }

    void Start()
    {		
        GameController.gamePaused += Pause;
    }

    void Update () {

        if (!paused)
        {
            Vector3 velocity = Vector3.left * speed * Time.deltaTime;
            transform.Translate(velocity);

            if (transform.position.x <= -(GameController.halfScreenSize + 5))
                Destroy(transform.gameObject);
        }

        
    }
}
