using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poor_balistics_launcher : MonoBehaviour {

 public Camera eyes;
 public GameObject projectile;
 public Transform rocket_spawn;
 public AudioClip shoot_clip;

 float hitForce = 50f;
 public float thrust = 150f;

 private float nextFire = 0.0F;
 private float fire_rate = 1f;

 bool reloaded = true;

 Rigidbody rrb;
 RaycastHit hit;
 Ray ray_beam;
 Animator anim;
 AudioSource src;
 public Light shoot_light;



 public float range = 1000f;

 	void Start (){
		hit = new RaycastHit();
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	void Update ()
	{
		Shoot();



	}

	void Shoot() {
		Debug.DrawRay(rocket_spawn.transform.position, rocket_spawn.transform.forward * range);

		//ray_beam = new Ray (rocket_spawn.transform.position, rocket_spawn.transform.forward);

		if (Input.GetButtonDown("Fire1") && Time.time > nextFire && reloaded) {
			Ray ray_beam = new Ray (rocket_spawn.transform.position, rocket_spawn.transform.forward);

			nextFire = Time.time + fire_rate;
			GameObject projectile_shot = Instantiate (projectile, rocket_spawn.transform.position, Quaternion.LookRotation(ray_beam.direction));
			rrb = projectile_shot.GetComponent<Rigidbody>();
			rrb.velocity = ray_beam.direction * thrust;

			Shoot_Sounds();

			StartCoroutine(Shoot_Light_Emmision());

			anim.SetTrigger("isFire");

			Destroy (projectile_shot, 10f);

		}

	}

	IEnumerator Shoot_Light_Emmision() {
		shoot_light.enabled = true;
		yield return new WaitForSeconds (0.1f);
		shoot_light.enabled = false;
	}

	void Shoot_Sounds() {
		src.clip = shoot_clip;
		src.Play();
	}

	public void Reloaded() {
		reloaded = !reloaded;
	}
}
