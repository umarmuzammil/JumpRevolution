using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {

    private bool paused = false;
	GameController gameController;

    void Pause(bool state)
    {
        paused = state;
    }

    void Start()
    {		
		gameController = FindObjectOfType<GameController> ();
        GameController.gamePaused += Pause;
    }

    void Update () {

        if (!paused)
        {
			Vector3 velocity = Vector3.left * gameController.moveSpeed * Time.deltaTime;
            transform.Translate(velocity);

            if (transform.position.x <= -(GameController.halfScreenSize + 5))
                Destroy(transform.gameObject);
        }

        
    }
}
