using UnityEngine;
using System.Collections;

public class OvrLook : MonoBehaviour {

	public OVRCameraController ovrController;
	public Camera ovrCamLeft;
	public Camera ovrCamRight;
	public Camera mainCamera;

	public MouseLook mouseLook;

	void Update ()
	{

		if (GameRole.singletonInstance.IsRunner) {


						if (OVRDevice.IsSensorPresent (0)) {
								ovrCamLeft.camera.enabled = true;
								ovrCamRight.camera.enabled = true;
								mainCamera.enabled = false;
								mouseLook.enabled = false;
								transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, ovrCamLeft.transform.eulerAngles.y, transform.localEulerAngles.z);
						} else {
								ovrCamLeft.camera.enabled = false;
								ovrCamRight.camera.enabled = false;
								mainCamera.enabled = true;
								mouseLook.enabled = true;
						}
				} else {
			mainCamera.enabled = false;
			ovrCamLeft.camera.enabled = false;
			ovrCamRight.camera.enabled = false;
		}
		
	}
	
	void Start ()
	{
	}
}