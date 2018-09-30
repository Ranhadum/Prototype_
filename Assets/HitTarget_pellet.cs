using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget_pellet : MonoBehaviour {

	public GameObject bulletHole;
	poor_balistics_shotgun pelletScript;

	void OnCollisionEnter (Collision col)
	{

		if (col.gameObject.tag == "playground") {
			Instantiate (bulletHole, gameObject.transform.position, Quaternion.FromToRotation(gameObject.transform.forward, Vector3.forward));
			Destroy (bulletHole, 12f);
		}

		Debug.Log (col.gameObject.name);
		Destroy (gameObject);

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

	void EnemyHit (){

	}
}
