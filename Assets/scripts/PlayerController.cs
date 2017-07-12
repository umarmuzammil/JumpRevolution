using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {


    //bool begin = false;
    Animator charAnimator;
    Rigidbody charRigidbody;

    void GameStarted()
    {
        //begin = true;
        charAnimator.SetBool("run", true);
    }

    void Start()
    {
        GameController.gameStarted += GameStarted;

        charAnimator = GetComponent<Animator>();
        charRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "cube")
                {
                    charAnimator.SetFloat("jump", 1f);
                    //charRigidbody.AddForce(Vector3.up * 4.5f, ForceMode.Impulse);
                    Vector3 newPos = hit.point + new Vector3(0, 0.25f, 0);

                    transform.DOMove(newPos, 2f).SetEase(Ease.InOutQuad).OnComplete(Arrived);
                }                
            }            
        }
    }


    void Arrived()
    {
        charAnimator.SetFloat("jump", 0f);
    }
}
