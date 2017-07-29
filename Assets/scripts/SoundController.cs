using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    public AudioSource background;
    public AudioSource gameplay;
    public AudioSource UI;

    [Header("Gameplay")]
    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;

    public AudioClip jump, fall;
    [Header("UI")]
    public AudioClip play;
    public AudioClip pause, restart;


	bool playBackgroundMusic = true;

	void Start()
	{
		Music ();
	}

    public void Music()
    {
		if (playBackgroundMusic) {
			background.clip = backgroundMusic1;
			background.Play ();
		}
		
    }


    public void Jump()
    {
		gameplay.clip = jump;
		gameplay.Play ();
    }
        
    

}
