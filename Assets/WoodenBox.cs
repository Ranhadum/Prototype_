using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBox : MonoBehaviour {

	public int _health;
	public GameObject box_destroyed;

	void Update ()
	{
		if (_health < 1) {
			Instantiate (box_destroyed, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
		}
	}
}
