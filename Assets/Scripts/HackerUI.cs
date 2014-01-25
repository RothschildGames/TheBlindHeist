using UnityEngine;
using System.Collections;

public class HackerUI : MonoBehaviour {

	public GUITexture win;
	public GUITexture lose;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void won(){
		win.enabled = true;
	}

	public void lost(){
		lose.enabled = true;
	}
}
