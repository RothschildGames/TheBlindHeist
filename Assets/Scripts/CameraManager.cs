using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {


	public Camera playerCamera;
	public List<SecurityCamera> cameras;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Alpha0)) {
			bringToFront(playerCamera);
		} else {
			for (int i=0; i < cameras.Count; i++) {
				if (Input.GetKeyUp (KeyCode.Alpha1 + i)){
					bringToFront(cameras[i].camera);
				}
			}
			if (Input.GetKeyUp (KeyCode.Equals)){
				playerCamera.enabled = true;
				playerCamera.camera.enabled = false;
				playerCamera.pixelRect = new Rect(0,0,Screen.width/2, Screen.height/2);

				cameras[0].camera.enabled = true;
				cameras[0].controlable = false;
				cameras[0].camera.pixelRect = new Rect(0,Screen.height/2,Screen.width/2, Screen.height/2);

				cameras[1].camera.enabled = true;
				cameras[1].controlable = false;
				cameras[1].camera.pixelRect = new Rect(Screen.width/2,Screen.height/2,Screen.width/2, Screen.height/2);


				cameras[2].camera.enabled = true;
				cameras[2].controlable = false;
				cameras[2].camera.pixelRect = new Rect(Screen.width/2,0,Screen.width/2, Screen.height/2);
			}
		}
	}

	void bringToFront (Camera c){
		disableAll ();
//		c.enabled = true;
		c.camera.enabled = true;
		if (c.GetComponent<SecurityCamera> ()) {
			c.GetComponent<SecurityCamera> ().controlable = true;
		}
	}

	void disableAll(){
		playerCamera.pixelRect = new Rect(0,0,Screen.width, Screen.height);
		playerCamera.camera.enabled = false;
		for (int i=0; i < cameras.Count; i++) {
			cameras[i].camera.enabled = false;
			cameras[i].controlable = false;;
			cameras[i].camera.pixelRect = new Rect(0,0,Screen.width, Screen.height);
		}

	}
}
