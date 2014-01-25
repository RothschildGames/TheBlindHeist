using UnityEngine;
using System.Collections;

public class OvrLook : MonoBehaviour {

	public Camera ovrCamLeft;
	public Camera ovrCamRight;
	public Camera mainCamera;

	public MouseLook mouseLook;

	void Update ()
	{
		if (OVRDevice.IsSensorPresent (0)) {
						ovrCamLeft.enabled = true;
						ovrCamRight.enabled = true;
						mainCamera.enabled = false;
						mouseLook.enabled = false;
						transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, ovrCamLeft.transform.eulerAngles.y, transform.localEulerAngles.z);
				} else {
			ovrCamLeft.enabled = false;
			ovrCamRight.enabled = false;
			mainCamera.enabled = true;
			mouseLook.enabled = true;
				}

	}
	
	void Start ()
	{
	}
}