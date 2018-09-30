using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTarget_projectile : MonoBehaviour {

	void OnCollisionEnter (Collision col){
		Debug.Log(col.gameObject.name);
		Destroy(gameObject);

		if (col.gameObject.GetComponent<Enemy> ()) {
			col.gameObject.GetComponent<Rigidbody> ().freezeRotation = false;
			Destroy (col.gameObject.GetComponent<CapsuleCollider> ());
		}

		if (col.gameObject.GetComponent<CharacterJoint> ()) {
			Destroy (col.gameObject.GetComponent<CharacterJoint> ());
		}

		if (col.gameObject.GetComponent<WoodenBox> ()) {
			col.gameObject.GetComponent<WoodenBox>()._health--; 
		}
	}

}
