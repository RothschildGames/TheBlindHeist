using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {


	public Camera playerCamera;
	public List<SecurityCamera> cameras;
	public SecurityCamera noiseCamera;

	private List<SecurityCamera> noiseCameras= new List<SecurityCamera>();

	private Rect[] rectPositions = {
		new Rect (0, Screen.height / 2, Screen.width / 2, Screen.height / 2),
		new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2),
		new Rect (Screen.width / 2, 0, Screen.width / 2, Screen.height / 2)
	};
	

	private SecurityCamera[] currentCameras;
	private int lastCamera;

	// Use this for initialization
	void Start () {

		currentCameras = new SecurityCamera[rectPositions.Length];
		lastCamera = currentCameras.Length - 1;
		for (int i = 0; i < currentCameras.Length; i++) {
			SecurityCamera c = (SecurityCamera) SecurityCamera.Instantiate (noiseCamera);
			c.camera.pixelRect = rectPositions[i];
			noiseCameras.Add (c);
			setCamera (cameras [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i < cameras.Count; i++) {
			if (Input.GetKeyUp (KeyCode.Alpha1 + i)) {
				int currCamLocation = findCurrCamera(cameras[i]);
				if (currCamLocation != -1) {
					setNoiseCamera(currCamLocation);
				}
				setCamera(cameras[i]);
			}
		}
	}

	void setNoiseCamera(int currCamLocation) {
		currentCameras[currCamLocation].controlable = false;
		currentCameras[currCamLocation].camera.enabled = false;
		currentCameras[currCamLocation] = noiseCameras[currCamLocation];
		noiseCameras[currCamLocation].camera.enabled = true;
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

	int findCurrCamera (SecurityCamera c) {
		for (int i =0 ; i < currentCameras.Length ; i++){
			if (currentCameras[i] == c) return i;
		}
		return -1;
	}
}
