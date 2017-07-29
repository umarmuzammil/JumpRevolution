using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {


	public static float halfScreenSize;

    //Game Starting Timer    Variables

    public Text countDown;
    public int countDownLength = 3;
    public Button playBtn;

    float time = 0;

    bool countDownFinished = false;
    bool startGame = false; 
    bool pauseGame = false;


    //Gamestarted Event 
    public delegate void GameStart();
    public static event GameStart gameStarted;


    public delegate void Pause(bool state);
    public static event Pause gamePaused;

    void Start()
    {
		halfScreenSize = Camera.main.orthographicSize * Camera.main.aspect;        
    }

    public void Play()
    {
        playBtn.gameObject.SetActive(false);
        pauseGame = false;
        startGame = true;
    }

    public void PauseGame()
    {
        pauseGame = !pauseGame;
        if (gamePaused != null)
            gamePaused(pauseGame);
    }

    void StartCountDown()
    {
        countDown.text = (countDownLength - (int)time).ToString();
        time += Time.deltaTime;

        if (time > countDownLength)
        {
            countDown.gameObject.SetActive(false);
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
}
