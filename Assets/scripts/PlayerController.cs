using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    bool begin = false;
    Animator charAnim; 

    void GameStarted()
    {
        begin = true;
        charAnim.SetBool("run", true);
    }

    void Start()
    {
        GameController.gameStarted += GameStarted;
        charAnim = GetComponent<Animator>();
    }
        
    void Update()
    {

    }


}
