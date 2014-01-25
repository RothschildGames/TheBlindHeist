using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public MovieTexture movieTx;
	public AudioClip audioSrc;

	// Use this for initialization
	void Start () {
		movieTx = guiTexture.texture as MovieTexture;
		audioSrc = movieTx.audioClip;

//		movieTx.audioClip

//		guiTexture.audio.pitch = 2.0f;

//		audioSrc.g
//		audioSrc.pitch = 2.0f;
		movieTx.loop = true;

		movieTx.Play ();
//		audioSrc.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Pause() {
		movieTx.Pause();
	}
}
