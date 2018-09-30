﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poor_balistics_minigun : MonoBehaviour {

 public Camera eyes;
 public GameObject projectile;
 public Transform projectile_spawn;
 public AudioClip shoot_clip;

 float hitForce = 50f;
 public float thrust = 150f;

 float fire_rate = 0.01f;
 private float nextFire = 0.0F;

 Rigidbody rrb;
 RaycastHit hit;
 Ray ray_beam;
 Animator anim;
 AudioSource src;
 public Light shoot_light;


 public float range = 1000f;
 float z = 80f;

 	void Start (){
		hit = new RaycastHit();
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		Shoot();
	}

	void Shoot ()
	{

		//ray_beam = new Ray (projectile_spawn.transform.position, projectile_spawn.transform.forward);

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {

			Shoot_Sounds ();
			shoot_light.enabled = true;

			Vector3 direction = Random.insideUnitCircle;
			direction.z = z;
			direction = transform.TransformDirection (direction.normalized);

			Ray ray_beam = new Ray (projectile_spawn.transform.position, direction);
			Debug.DrawRay (projectile_spawn.transform.position, projectile_spawn.transform.forward * range);

			nextFire = Time.time + fire_rate;
			GameObject projectile_shot = Instantiate (projectile, projectile_spawn.transform.position, Quaternion.LookRotation (ray_beam.direction));
			rrb = projectile_shot.GetComponent<Rigidbody> ();
			rrb.velocity = ray_beam.direction * thrust;



			anim.SetTrigger ("isFire");
			anim.SetTrigger ("isFireCon");

			Destroy (projectile_shot, 6f);

		} else {
			shoot_light.enabled = false;
		}

	}

	void Shoot_Sounds() {
		src.clip = shoot_clip;
		src.Play();
	}

}
