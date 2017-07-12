using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBlocks : MonoBehaviour {


    //Delay min max Values
    int minDelay = 1;
    int maxDelay = 3;


    public GameObject baseBlock;

    float time = 0;
	bool begin = false;

	void GameStarted()
	{
		begin =  true;
        //Add MoveScript to Existing Block
        baseBlock.AddComponent<MoveBlocks>();
    }

    void Start()
    {
		GameController.gameStarted += GameStarted;
    }


    void Update()
    {
     
		if (begin)
        {
            if (time == 0)
            {        
                InstantiateBlocks();   
            }
            time += Time.deltaTime;

			int delay = Random.Range (minDelay, maxDelay);
			if (time > delay)
                time = 0;
        }
    }
    void InstantiateBlocks()
    {
        //Position Parameters
        float minPosY = 0;
        float maxPosY = 2.5f;

		//Scale Parameters

		float minScaleX = 1f;
		float maxScaleX = 3f;

		float minScaleZ = 0.5f;
		float maxScaleZ = 1f;


        float posY = Random.Range(minPosY, maxPosY);
        float scaleX = Random.Range(minScaleX, maxScaleX);
        float scaleZ = Random.Range(minScaleZ, maxScaleZ);


        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(GameController.halfScreenSize+3.5f, posY, 0);
        cube.transform.localScale = new Vector3(scaleX, 0.5f, scaleZ);

        cube.transform.SetParent(transform);

		cube.AddComponent<MoveBlocks>();
        //cube.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
 
}
