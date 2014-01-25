using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {
	public Camera playerCamera;
	public List<SecurityCamera> cameras;
	public SecurityCamera noiseCamera;
	public float switchTimeout = 0.5f;
	public PlayVideo hackerType;
	public GUIStyle cameraIndicatorStyle;

	private List<SecurityCamera> noiseCameras= new List<SecurityCamera>();

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

	private float[] transitionTimestamp;
	private SecurityCamera[] transitionTo;

	private SecurityCamera[] currentCameras;
	private int lastCamera;

    void Awake()
    {
        gameObject.SetActive(!Network.isServer);
    }

	// Use this for initialization
	void Start () {
		currentCameras = new SecurityCamera[rectPositions.Length];
		transitionTimestamp = new float[rectPositions.Length];
		transitionTo = new SecurityCamera[rectPositions.Length];
		lastCamera = currentCameras.Length - 1;
		for (int i = 0; i < currentCameras.Length; i++) {
			transitionTimestamp[i] = float.MaxValue;
			SecurityCamera c = (SecurityCamera) SecurityCamera.Instantiate (noiseCamera);
			c.camera.pixelRect = rectPositions[i];
			noiseCameras.Add (c);
			setCamera (i, cameras [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < transitionTimestamp.Length; ++i) {
			if (Time.fixedTime > transitionTimestamp[i]) {
				transitionTimestamp[i] = float.MaxValue;
				switchCamera (i, transitionTo[i]);
			}
		}
		for (int i=0; i < cameras.Count; i++) {
			if (Input.GetKeyUp (KeyCode.Alpha0 + ((i + 1) % 10))) {
				int setCamLocation = findCurrCamera(cameras[i]);
				if (setCamLocation == -1) {
					lastCamera = (lastCamera + 1) % 3;
					setCamLocation = lastCamera;
				}
				setCamera(setCamLocation, cameras[i]);
			}
		}
	}

	void OnGUI() {
		for (int i = 0; i < currentCameras.Length; i++) {
			int index = cameras.IndexOf (currentCameras [i]) + 1;
			GUI.Label (guiPositions [i], index.ToString (), cameraIndicatorStyle);
		}
	}


	void setNoiseCamera(int currCamLocation) {
		currentCameras[currCamLocation].controlable = false;
		currentCameras[currCamLocation].camera.enabled = false;
		currentCameras[currCamLocation] = noiseCameras[currCamLocation];
		noiseCameras[currCamLocation].camera.enabled = true;
	}

	void setCamera (int camLocation, SecurityCamera c) {
		foreach (SecurityCamera sc in cameras) {
			sc.controlable = false;
		}
		if (currentCameras[camLocation]) currentCameras[camLocation].camera.enabled = false;
		currentCameras[camLocation] = c;
		transitionTimestamp[camLocation] = Time.fixedTime + switchTimeout;
		transitionTo[camLocation] = c;
		noiseCameras[camLocation].camera.enabled = true;
	}

	void switchCamera(int camLocation, SecurityCamera c) {
		foreach (SecurityCamera sc in cameras) {
			sc.controlable = false;
		}
		noiseCameras[camLocation].camera.enabled = false;
		c.camera.pixelRect = rectPositions [camLocation];
		c.camera.enabled = true;
		c.controlable = true;
		currentCameras [camLocation] = c;
	}

	int findCurrCamera (SecurityCamera c) {
		for (int i =0 ; i < currentCameras.Length ; i++){
			if (currentCameras[i] == c) return i;
		}
		return -1;
	}

	public void initEndGame(bool isWon) {
		if (GameRole.singletonInstance.IsRunner) return;
		for (int i = 0; i < currentCameras.Length; ++i) {
			currentCameras[i].camera.enabled = false;
			currentCameras[i].controlable = false;
			noiseCameras[i].camera.enabled = true;
		}
		hackerType.Pause();
		this.enabled = false;
	}
}
