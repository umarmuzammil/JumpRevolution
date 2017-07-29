using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{


    private bool begin = false;
    private bool paused = false;
    private GameObject activeBlock;
	private GameObject previousBlock;
    private Animator charAnimator;

	Vector3 playerInitialPos = new Vector3 (-1f,-0.25f,0f);

	SoundController soundController;
	GameController gameController;
    [Range(0.1f,1)]
    public float jumpspeed = 0.3f;

    void Pause(bool state)
    {
        paused = state;
    }

    void GameStarted()
    {        
        begin = true;
    }

    void Start()
    {
		
		previousBlock = activeBlock = GameObject.FindGameObjectWithTag ("cube");


        //Game Events
		soundController = FindObjectOfType<SoundController>();
		gameController = FindObjectOfType<GameController>();


        GameController.gameStarted += GameStarted;
        GameController.gamePaused += Pause;
		GameController.reset += Reset;


        charAnimator = GetComponent<Animator>();
    }

	void Reset()
	{
		previousBlock = activeBlock = GameObject.FindGameObjectWithTag ("cube");
		transform.position = playerInitialPos;
		Pause (false);
	}

    void Update()
    {
        if (!paused)
        {
            if (begin)
            {
                if (transform.position.x > -2.25f)
                {
                    Vector3 activeposition = new Vector3(transform.position.x - MoveBlocks.speed * Time.deltaTime, transform.position.y, transform.position.z);
                    transform.position = activeposition;
                }

            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.tag == "cube")
                    {
						previousBlock = activeBlock;
                        activeBlock = hit.transform.gameObject;	

						if (!(activeBlock == previousBlock)) {
							charAnimator.SetFloat ("jump", 1f);
							Vector3 newPos = new Vector3 (hit.point.x - (MoveBlocks.speed * jumpspeed), hit.point.y + 0.1f, 0);
							soundController.Jumped ();
							transform.DOJump (newPos, 1f, 1, jumpspeed, false).SetEase (Ease.InOutQuint).OnComplete (Arrived);
						}

                    }
                }
            }
        }
    }


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Respawn") {
			gameController.GameisOver ();
			soundController.Crashed ();
		}
	}


    void Arrived()
    {                
        charAnimator.SetFloat("jump", 0f);
    }
}
