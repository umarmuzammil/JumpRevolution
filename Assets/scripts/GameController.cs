using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {


	public static float halfScreenSize;

    //Game Starting Timer    Variables
	public Button pausebtn;
    public Text countDowntxt;
    public int countDownLength = 3;
    public Button playBtn;
	public Button replaybtn;
	SoundController sound;

    float time = 0;

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
        if (startGame && !countDownFinished)
            StartCountDown();
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

