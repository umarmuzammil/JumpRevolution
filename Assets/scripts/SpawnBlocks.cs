using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBlocks : MonoBehaviour {


    //Delay min max Values
    private int minDelay = 1;
    private int maxDelay = 2;
    private float time = 0;
    private bool begin = false;
    private bool paused = false;

    public GameObject baseBlockPrefab;
	GameObject baseBlock;
	List<GameObject> spawedBlocks = new List<GameObject>();


	public Material blockMaterial;
    

	void GameStarted()
	{
		begin =  true;
		Pause (false);
        baseBlock.AddComponent<MoveBlocks>();
    }

    void Pause(bool state)
    {
        paused = state;
    }

    void Start()
    {
		
		baseBlock = Instantiate (baseBlockPrefab, transform);
		GameController.gameStarted += GameStarted;
        GameController.gamePaused += Pause;
		GameController.reset += Reset;

    }

	void Reset()
	{
		if (spawedBlocks.Count > 0) {		
			for (int i = 0; i < spawedBlocks.Count; i++)
				Destroy (spawedBlocks [i]);
		}
		spawedBlocks.Add(baseBlock = Instantiate (baseBlockPrefab, transform));
		time = 0;
	}

    void Update()
    {
        if (!paused)
        {
            if (begin)
            {
                if (time == 0)
                {
                    InstantiateBlocks();
                }
                time += Time.deltaTime;

                int delay = Random.Range(minDelay, maxDelay);
                if (time > delay)
                    time = 0;
            }
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

		//float minScaleZ = 0.5f;
		//float maxScaleZ = 1f;


		float posY = Random.Range(minPosY, maxPosY);
        float scaleX = Random.Range(minScaleX, maxScaleX);
       // float scaleZ = Random.Range(minScaleZ, maxScaleZ);


        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(GameController.halfScreenSize+3.5f+(scaleX/2+2f), posY, 0);
        cube.transform.localScale = new Vector3(scaleX, 0.5f, 1);

		Color blockcolor = new Color (Random.value, Random.value, Random.value, 1f);

		cube.GetComponent<MeshRenderer> ().material.color = blockcolor;
        cube.transform.SetParent(transform);
		cube.AddComponent<MoveBlocks>();
        cube.tag = "cube";
		spawedBlocks.Add (cube);
    }
 
}
