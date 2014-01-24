using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour {

	public float speed = 1.0f;
	public float angle = 45f;

	private float startY;
	private int direction = 1;

	// Use this for initialization
	void Start () {
		startY = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, Time.deltaTime * speed * direction);
		if (transform.rotation.y > startY + (angle * Mathf.Deg2Rad) / 2) { 
			direction = -1;
		} else if (transform.rotation.y < startY - (angle * Mathf.Deg2Rad) / 2) {
			direction = 1;
		}
	}
}
