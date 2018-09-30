using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public GameObject Shoot_Thing;
	public Transform Shoot_position;

	public float thrust;

	Rigidbody rb;

	void FixedUpdate ()
	{
		StartCoroutine(Shooting ());
	}
	IEnumerator Shooting() {

		if (Input.GetButtonDown ("Fire1")) {
			GameObject projectile = Instantiate(Shoot_Thing, Shoot_position.transform.position, Shoot_position.transform.rotation);

			rb = projectile.GetComponent<Rigidbody>();
			rb.velocity = projectile.transform.forward * thrust;

			yield return new WaitForSeconds(1f);
			rb.useGravity = true;

			Destroy(projectile, 5f);
		}
	}
}
