using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour {

	Animator anim;

	public void Start () {

		anim = GetComponent<Animator>();
	}

	void OnCollisionEnter(Collision col)
	{

		if (col.collider.tag == "playground") {
			GetComponent<characterController>().isGrounded = true;
			GetComponent<characterController>().jump_state = false;
		}

	}
}
