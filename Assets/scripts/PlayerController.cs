using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{


    bool begin = false;
    public GameObject firstBlock;

    Animator charAnimator;
    GameObject activeBlock;

    void GameStarted()
    {
        activeBlock = firstBlock;
        begin = true;
    }

    void Start()
    {
        GameController.gameStarted += GameStarted;
        charAnimator = GetComponent<Animator>();
    }

    void Update()
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
                    Vector3 newPos = new Vector3(hit.point.x, hit.point.y+0.25f, 0);
                    transform.DOJump(newPos, 1f, 1, 0.3f, false).SetEase(Ease.InOutQuad).OnComplete(Arrived);
                }
            }
        }
    }


    void Arrived()
    {
        charAnimator.SetFloat("jump", 0f);
    }
}
