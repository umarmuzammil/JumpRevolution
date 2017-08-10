using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {


	public static float halfScreenSize;
	public float moveSpeed = 3;
	public float DifficultyIncreaseValue = 1.2f;
    //Game Starting Timer    Variables
	public Button pausebtn;
    public Text countDowntxt;
    public int countDownLength = 3;
    public Button playBtn;
	public Button replaybtn;
	SoundController sound;

    float time = 0;
	int difficulty = 0; 

	bool countDownFinished,startGame,pauseGame = false;

    //Gamestarted Event 
    public delegate void GameStart();
	public delegate void Pause(bool state);
	public delegate void Reset();
    public static event GameStart gameStarted;
    public static event Pause gamePaused;
	public static event Reset reset;

    void Start()
    {
		sound = FindObjectOfType<SoundController>();
		halfScreenSize = Camera.main.orthographicSize * Camera.main.aspect;  
    }

    public void Play()
    {
		
		sound.BtnPressed ();
        playBtn.gameObject.SetActive(false);
		countDowntxt.gameObject.SetActive(true);

        pauseGame = false;
        startGame = true;
    }

    public void PauseGame()
    {
		sound.BtnPressed ();
        pauseGame = !pauseGame;
        if (gamePaused != null)
            gamePaused(pauseGame);
    }
    void StartCountDown()
    {
		countDowntxt.text = (countDownLength - (int)time).ToString();
        time += Time.deltaTime;

        if (time > countDownLength)
        {
			countDowntxt.gameObject.SetActive(false);
            countDownFinished = true;

            if (gameStarted != null)
                gameStarted();
        }
    }




    void Update()
    {
		GameDifficulty ();
        if (startGame && !countDownFinished)
            StartCountDown();
    }

	void GameDifficulty()
	{		
		if (Time.time < 10 && difficulty == 0) {
			difficulty = 1;
			return;
		}
		else if (Time.time > 30 && Time.time < 60 && difficulty == 1){		
			moveSpeed = moveSpeed*DifficultyIncreaseValue;
			difficulty = 2;
		}
		else if (Time.time > 60 && Time.time < 100 && difficulty == 2){		
			moveSpeed = moveSpeed*DifficultyIncreaseValue;
			difficulty = 3;
		}
		else if (Time.time > 100 && Time.time < 150 && difficulty == 3){		
			moveSpeed = moveSpeed*DifficultyIncreaseValue;
			difficulty = 4;
		}
		else if (Time.time > 150 && Time.time < 300 && difficulty == 4 ){		
			moveSpeed = moveSpeed*DifficultyIncreaseValue;
			difficulty = 5;
		}
		else if (Time.time > 300 && Time.time < 500 && difficulty == 5){		
			moveSpeed = moveSpeed*DifficultyIncreaseValue;
			difficulty = 6;
		}

	}

	public void GameisOver()
	{
		countDownFinished = startGame = pauseGame = false;

		pauseGame = !pauseGame;
		if (gamePaused != null)
			gamePaused(pauseGame);

		replaybtn.gameObject.SetActive(true);
		playBtn.gameObject.SetActive(false);
		pausebtn.gameObject.SetActive(false);

	}

	public void ResetGame()
	{
		countDownFinished = pauseGame = false;

		playBtn.gameObject.SetActive(false);
		replaybtn.gameObject.SetActive(false);
		pausebtn.gameObject.SetActive(true);
		countDowntxt.gameObject.SetActive(true);


		time = 0f;
		if (reset != null)
			reset();
		
		startGame = true;


	}

}

