using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour {

	public float speed = 1.0f;
	public float angle = 45f;
	public float timeout = 2f;

	private float startY;
	private int direction = 1;

	public KeyCode leftKey = KeyCode.LeftArrow;
	public KeyCode rightKey = KeyCode.RightArrow;

	private float lastChange = 0f;

	// Use this for initialization
	void Start () {
		startY = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.enabled) ManualCamera ();
		if (lastChange + timeout < Time.time) {
			AutomaticCamera();
		}
	}
	
	void ManualCamera(){
		if (Input.GetKey (leftKey)) {
			if (!atMin()) {
				transform.Rotate (Vector3.up, Time.deltaTime * speed * -1);
			}
			lastChange = Time.time;
			return;
		} else if (Input.GetKey (rightKey)) {
			if (!atMax()) { 
				transform.Rotate (Vector3.up, Time.deltaTime * speed * 1);
			}
			lastChange = Time.time;
			return;
		}
	}

	void AutomaticCamera() {
		
		if (atMax()) { 
			direction = -1;
		} else if (atMin()) {
			direction = 1;
		}
		transform.Rotate (Vector3.up, Time.deltaTime * speed * direction);
	}

	bool atMin(){
		return transform.rotation.y < startY - (angle * Mathf.Deg2Rad) / 2;
	}

	bool atMax(){
		return transform.rotation.y > startY + (angle * Mathf.Deg2Rad) / 2;
	}
}
