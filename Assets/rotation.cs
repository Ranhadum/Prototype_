using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	Rigidbody rb;

	void Update () {
		rb = GetComponent<Rigidbody>();
		transform.rotation = Quaternion.LookRotation(rb.velocity);
	}
}
