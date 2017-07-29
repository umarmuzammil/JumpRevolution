using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    public AudioSource gameMusicSource;
	public AudioSource uiMusicSource;
    public AudioSource playerSource;
	public AudioSource buttonsSource;


    [Header("Gameplay")]
    public AudioClip music_a;
    public AudioClip music_b;
    public AudioClip music_c;

    public AudioClip jump, fall;

    [Header("UI")]
	public AudioClip music;
    public AudioClip buttons;

	void Start()
	{
		GameController.gameStarted += GameStarted;

		UIMusic (true);
	}

	public void UIMusic(bool play = true)
	{
		if (play) {		
			uiMusicSource.clip = music;
			uiMusicSource.Play();
		} else
			uiMusicSource.Stop ();
	}

	void GameStarted()
	{		
		UIMusic (false);
		BGMusic (true);
	}


	public void BGMusic(bool play)
    {
		if (play) {
			gameMusicSource.clip = music_a;
			gameMusicSource.Play ();
		} else
			gameMusicSource.Stop ();		
    }


	public void BtnPressed()
	{
		buttonsSource.clip = buttons;
		buttonsSource.Play ();
	}

	public void Crashed()
	{
		playerSource.clip = fall;
		playerSource.Play ();
	}

    public void Jumped()
    {
		playerSource.clip = jump;
		playerSource.Play ();
    }
        
    

}
