using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{


    private bool begin = false;
    private bool paused = false;
    private GameObject activeBlock;
    private Animator charAnimator;

	SoundController sound;

    public GameObject firstBlock;
    [Range(0.1f,1)]
    public float jumpspeed = 0.3f;

    void Pause(bool state)
    {
        paused = state;
    }

    void GameStarted()
    {
        activeBlock = firstBlock;
        begin = true;
    }

    void Start()
    {
        //Game Events
		sound = FindObjectOfType<SoundController>();
        GameController.gameStarted += GameStarted;
        GameController.gamePaused += Pause;


        charAnimator = GetComponent<Animator>();
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
                        activeBlock = hit.transform.gameObject;
                        charAnimator.SetFloat("jump", 1f);
                        Vector3 newPos = new Vector3(hit.point.x - (MoveBlocks.speed * jumpspeed), hit.point.y + 0.1f, 0);
						sound.Jump ();
						transform.DOJump(newPos, 1f, 1, jumpspeed, false).SetEase(Ease.InOutQuint).OnComplete(Arrived);

                    }
                }
            }
        }
    }


    void Arrived()
    {                
        charAnimator.SetFloat("jump", 0f);
    }
}
