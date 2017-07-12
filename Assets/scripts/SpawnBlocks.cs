using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBlocks : MonoBehaviour {

	int minDelay = 1; 
	int maxDelay = 3; 


	public GameObject baseBlock;

    float time = 0;
	bool begin = false;

	void GameStarted()
	{
		begin =  true;
	}

    void Start()
    {
		GameController.gameStarted += GameStarted;
    }


    void Update()
    {
     

		if (begin)
        {
			if(baseBlock)
				baseBlock.AddComponent<MoveBlocks> ();
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
		int minPosY = 0;
		int maxPosy = 0;

		int minPosZ = 0;
		int maxPosZ = 0;

		//Scale Parameters

		int minScaleX = 0;
		int maxScaleX = 0;

		int minScaleY = 0;
		int maxScaleY = 0;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(GameController.halfScreenSize+3.5f, -0.5F, 0);
        cube.transform.localScale = new Vector3(2, 0.5f, 1f);

        cube.transform.SetParent(transform);

		cube.AddComponent<MoveBlocks>();
        //cube.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
 
}
