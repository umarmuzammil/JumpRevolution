using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocksAI : MonoBehaviour {

    float halfScreenSize;

    public Text countDown;
    int countDownLength = 3;
    float time = 0;



    bool startGame = false;

    void Start()
    {
        halfScreenSize = Camera.main.orthographicSize * Camera.main.aspect;     
    }

    void StartCountDown()
    {
        countDown.text = (countDownLength - (int)time).ToString();
        time += Time.deltaTime;

        if(time > countDownLength)       
        {
            countDown.gameObject.SetActive(false);
            startGame = true;
            time = 0;
        }
     }
    

    void Update()
    {
        if(!startGame)
            StartCountDown();

        

        if (startGame)
        {

            if (time == 0)
            {        
                InstantiateBlocks();   
            }
            time += Time.deltaTime;

            if (time > 2)
                time = 0;
        }



    }
    void InstantiateBlocks()
    {   

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(halfScreenSize+3.5f, -0.5F, 0);
        cube.transform.localScale = new Vector3(2, 0.5f, 0.5f);

        cube.transform.SetParent(transform);

        cube.AddComponent<BlocksMovement>();
        //cube.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
 
}
