using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {


	Rigidbody body;

	void Start () {
	body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.UpArrow)) {
			body.AddForce(Vector3.forward * 500);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			body.AddForce(Vector3.back * 500);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			body.AddForce(Vector3.left * 500);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			body.AddForce(Vector3.right * 500);
		}
	}
}
