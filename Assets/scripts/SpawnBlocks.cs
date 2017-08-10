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

	Vector3 cameraInitialPos;
	Vector3 cameraPreviousPos;
	public Material blockMaterial;

	int colorindex = 0;
	[Header("Block Properties")]
	public Color clickableColor;


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
		cameraPreviousPos = Camera.main.transform.position;

		Reset ();
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
		baseBlock.layer = LayerMask.NameToLayer ("Blocks");
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
		
		Vector3 cameraOffset = Vector3.zero;

		if (Camera.main.transform.position != cameraPreviousPos) {			
			cameraOffset = Camera.main.transform.position - cameraPreviousPos;
			cameraPreviousPos = Camera.main.transform.position;
		}
		//Position Parameters
        float minPosY = 0;
        float maxPosY = 2.5f;

		//Scale Parameters

		float minScaleX = 1f;
		float maxScaleX = 3f;

		float posY = Random.Range(minPosY, maxPosY);
        float scaleX = Random.Range(minScaleX, maxScaleX);


        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(GameController.halfScreenSize+3.5f+(scaleX/2+2f), posY + cameraOffset.y, 0);
        cube.transform.localScale = new Vector3(scaleX, 0.5f, 1);

		Color blockcolor;
		if (colorindex == 0 || colorindex == 2 ) {
			 blockcolor = clickableColor;


		}
		else {
			 
			blockcolor = new Color (Random.value, Random.value, Random.value, 1f);
		}
		colorindex = colorindex + 1;

		if (colorindex > 3)
			colorindex = 0;


		cube.tag = "cube";
		cube.layer = LayerMask.NameToLayer("Blocks");
		cube.GetComponent<MeshRenderer> ().material.color = blockcolor;
        cube.transform.SetParent(transform);
		cube.AddComponent<MoveBlocks>();
		spawedBlocks.Add (cube);
    }
 
}
