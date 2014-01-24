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
			Application.LoadLevel(1);
		}
	
		if(GUI.Button(new Rect(325,300,300,60), "Host Server")) {
			Application.LoadLevel(1);
		}

		if(GUI.Button(new Rect(325,400,300,60), "Join Existing Gamer")) {
			Application.LoadLevel(2);
		}
	}
}
