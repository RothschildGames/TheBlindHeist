using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
public class ResultLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiTexture.enabled = (Time.time % 2) == 0;
	}
}
