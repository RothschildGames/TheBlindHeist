using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

	public AudioSource intro;
	public AudioSource loop;
	public AudioSource win;
	public AudioSource lose;

	private bool gameStarted = false;
	private bool endOfGame = false;
	private bool isVictory = false;
	private bool finalSequenceDone = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted && !endOfGame && !intro.isPlaying && !loop.isPlaying) {
			loop.Play();
		}
		if (endOfGame && !loop.isPlaying && !finalSequenceDone) {
			if (isVictory) {
				win.Play ();
			} else {
				lose.Play ();
			}
			finalSequenceDone = true;
		}
	}

	public void StartGame() {
		intro.Play();
		gameStarted = true;
	}

	public void lost() {
		if (!gameStarted) return;
		endOfGame = true;
		loop.loop = false;
		isVictory = false;
	}

	public void won() {
		if (!gameStarted) return;
		endOfGame = true;
		loop.loop = false;
		isVictory = true;
	}
}
