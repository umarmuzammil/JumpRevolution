using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {


	public static float halfScreenSize;

    //Game Starting Timer    Variables

    public Text countDown;
    public int countDownLength = 3;
    float time = 0;

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
            startGame = true;

            if (gameStarted != null)
                gameStarted();
        }
    }

    // Update is called once per frame
    void Update () {

        if (!startGame)
            StartCountDown();
    }
}
