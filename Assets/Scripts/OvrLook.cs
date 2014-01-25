using UnityEngine;
using System.Collections;

public class OvrLook : MonoBehaviour {

	public Camera ovrCam;

	void Update ()
	{
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, ovrCam.transform.eulerAngles.y, transform.localEulerAngles.z);
	}
	
	void Start ()
	{
	}
}