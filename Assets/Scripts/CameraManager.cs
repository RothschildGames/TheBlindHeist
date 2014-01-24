using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {


	public Camera playerCamera;
	public List<SecurityCamera> cameras;

	private Rect[] rectPositions = {
		new Rect (0, Screen.height / 2, Screen.width / 2, Screen.height / 2),
		new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2),
		new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height / 2)
	};

	private Rect[] guiPositions = {
		new Rect (0, 0, Screen.width / 2, Screen.height / 2),
		new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height / 2),
		new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2)
	};

	private SecurityCamera[] currentCameras;
	private int lastCamera;

	// Use this for initialization
	void Start () {

		currentCameras = new SecurityCamera[rectPositions.Length];
		lastCamera = currentCameras.Length - 1;
		for (int i = 0; i < currentCameras.Length; i++) {
			setCamera (cameras [i]);
		}

	}

	
	// Update is called once per frame
	void Update () {
		for (int i=0; i < cameras.Count; i++) {
			if (Input.GetKeyUp (KeyCode.Alpha1 + i) && !isCurrent(cameras[i])){
				setCamera(cameras[i]);
			}
		}
	}

	void OnGUI()
	{
		for (int i = 0; i < currentCameras.Length; i++) {
			int index = cameras.IndexOf(currentCameras[i]) + 1;
			GUI.Label (guiPositions[i], index.ToString());
		}
	}

	void setCamera (SecurityCamera c) {
		int nextCamera = (lastCamera + 1) % currentCameras.Length;
		if (currentCameras [nextCamera]) currentCameras [nextCamera].camera.enabled = false;
		if (currentCameras [lastCamera]) currentCameras [lastCamera].controlable = false;
		c.camera.pixelRect = rectPositions [nextCamera];
		c.camera.enabled = true;
		c.controlable = true;
		currentCameras [nextCamera] = c;
		lastCamera = nextCamera;
	}

	bool isCurrent (SecurityCamera c){
		for (int i =0 ; i < currentCameras.Length ; i++){
			if (currentCameras[i] == c) return true;
		}
		return false;
	}
}
