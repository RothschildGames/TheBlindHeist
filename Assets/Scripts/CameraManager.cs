using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {


	public Camera playerCamera;
	public List<Camera> cameras;

	private Camera current;

	// Use this for initialization
	void Start () {
		current = playerCamera;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha0)) {
			current.enabled = false;
			playerCamera.enabled = true;
			current = playerCamera;
		} else {
			for (int i=0; i < cameras.Count; i++) {
				if (Input.GetKey (KeyCode.Alpha1 + i)){
					current.enabled = false;
					cameras[i].enabled = true;
					current = cameras[i];
				}
			}
		}
	}
}
