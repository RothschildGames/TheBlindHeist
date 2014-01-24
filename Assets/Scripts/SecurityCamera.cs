using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class SecurityCamera : MonoBehaviour {

	public float speed = 10.0f;
	public float manualSpeed = 20.0f;
	public float angle = 45f;
	public float timeout = 2f;

	internal bool controlable = false;
	
	private float targetMin;
	private float targetMax;
	private int direction = 1;

	private bool checkMin = false;
	private bool checkMax = false;

	public KeyCode leftKey = KeyCode.LeftArrow;
	public KeyCode rightKey = KeyCode.RightArrow;

	private float lastChange = -100f;

	// Use this for initialization
	void Start () {
		targetMin = transform.rotation.eulerAngles.y - angle / 2;
		targetMax = transform.rotation.eulerAngles.y + angle / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (controlable) ManualCamera ();
		if (lastChange + timeout < Time.time) {
			AutomaticCamera();
		}
	}
	
	void ManualCamera(){
		if (Input.GetKey (leftKey)) {
			if (!atMin()) {
				transform.Rotate (Vector3.up, Time.deltaTime * manualSpeed * -1);
			}
			lastChange = Time.time;
			return;
		} else if (Input.GetKey (rightKey)) {
			if (!atMax()) { 
				transform.Rotate (Vector3.up, Time.deltaTime * manualSpeed * 1);
			}
			lastChange = Time.time;
			return;
		}
	}

	void AutomaticCamera() {
		if ((direction == -1) && atMin ()){
			direction = 1;
			checkMin = false;
		} else if ((direction == 1) && atMax()){
			direction = -1;
			checkMax = false;
		}

		transform.Rotate (Vector3.up, Time.deltaTime * speed * direction);
	}

	bool atMin(){
		float delta = Mathf.DeltaAngle (transform.rotation.eulerAngles.y, targetMin);
		if (checkMin) return delta > 0;
		checkMin = delta < 0;
		return false;
	}

	bool atMax(){
		float delta = Mathf.DeltaAngle (transform.rotation.eulerAngles.y, targetMax);
		if (checkMax) return delta < 0;
		checkMax = delta > 0;
		return false;
	}
}
