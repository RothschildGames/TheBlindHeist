using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {


	public Camera playerCamera;
	public List<Camera> cameras;
//	private KeyCode[] keyCodes = {KeyCode.Alpha0, KeyCode.Alpha1, };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Alpha0)) {
			Camera.current.enabled = false;
			playerCamera.enabled = true;
		} else {
			for (int i=0; i < cameras.Count; i++) {
				if (Input.GetKey (KeyCode.Alpha1 + i)){
					Camera.current.enabled = false;
					cameras[i].enabled = true;
				}
			}
		}
	}
}
