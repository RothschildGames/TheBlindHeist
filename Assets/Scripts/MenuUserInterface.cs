using UnityEngine;
using System.Collections;

public class MenuUserInterface : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {


		if(GUI.Button(new Rect(325,200,300,60), "Start Local Game")) {
			Application.LoadLevel("LevelScene");
		}
	}
}
