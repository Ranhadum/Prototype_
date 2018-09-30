using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

	public GameObject rocket;
	public Transform shoot_pos;

	Rigidbody rb;

	[SerializeField]
	[Range(10f, 80f)]
	private float angle = 45f;


	void Update ()
	{
		if (Input.GetButtonDown("Fire1")) {
			
			GameObject projectile = Instantiate(rocket, shoot_pos.transform.position, shoot_pos.transform.rotation) as GameObject;
			rb = projectile.GetComponent<Rigidbody>();

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit hitInfo;

			if (Physics.Raycast (ray, out hitInfo)) 
			{
				LaunchRocket(hitInfo.point);
			}
		}
	}

	void LaunchRocket (Vector3 point)
	{
		var velocity = VelocityBallistic(point, angle);

		Debug.Log("Firing at " + point + " velocity " + velocity);

		rb.transform.position = transform.position;
		rb.velocity = velocity; 
	}

	private Vector3 VelocityBallistic (Vector3 destination, float angle)
	{
		Vector3 direction = destination - transform.position;

		float height = direction.y;
		direction.y = 0;

		float dist = direction.magnitude;
		float a = angle * Mathf.Deg2Rad;

		direction.y = dist * Mathf.Tan(a);
		dist += height / Mathf.Tan(a);

		float velocity = Mathf.Sqrt (dist * Physics.gravity.magnitude / Mathf.Sin(2*a));
		return velocity * direction.normalized;
	}
}
