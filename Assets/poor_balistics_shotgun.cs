using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poor_balistics_shotgun : MonoBehaviour {

 public Camera eyes;
 public GameObject projectile;
 public Transform projectile_spawn;
 public AudioClip shoot_clip;
 public AudioClip reload_clip;
 public ParticleSystem smokeVFX;

 float hitForce = 10f;
 public float thrust = 250f;

 float fire_rate = 2f;
 int pellets = 10;
 private float nextFire = 0F;

 Rigidbody rrb;
 public RaycastHit hit;
 public Ray ray_beam;
 public Vector3 direction;
 Animator anim;
 AudioSource src;
 public Light shoot_light;

 bool reloaded = true;


 public float range = 1000f;
 float z = 16f;

 	void Start (){
		hit = new RaycastHit();
		anim = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	void Update()
	{
		Shoot();
	}

	public void Shoot ()
	{

		//ray_beam = new Ray (projectile_spawn.transform.position, projectile_spawn.transform.forward);

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			

			nextFire = Time.time + fire_rate;
			for (var i = 0; i < pellets; i++) {

				Vector3 direction = Random.insideUnitCircle;
				direction.z = -z;
				direction = transform.TransformDirection (direction.normalized);
				ray_beam = new Ray (projectile_spawn.transform.position, direction);
	
				GameObject projectile_shot = Instantiate (projectile, projectile_spawn.transform.position, Quaternion.LookRotation (ray_beam.direction));
				rrb = projectile_shot.GetComponent<Rigidbody> ();
				rrb.velocity = ray_beam.direction * thrust;

				Destroy (projectile_shot, 10f);

			}
			Shoot_Sounds ();

			StartCoroutine (Shoot_Light_Emmision ());

			anim.SetTrigger ("isFire");

		}
	}

	IEnumerator Shoot_Light_Emmision() {
		shoot_light.enabled = true;
		yield return new WaitForSeconds (0.1f);
		shoot_light.enabled = false;
		smokeVFX.Play();
	}

	void Shoot_Sounds() {
		src.clip = shoot_clip;
		src.Play();
	}

	public void Reloaded() {
		reloaded = !reloaded;
	}
	public void Reloading_play ()
	{
		src.clip = reload_clip;
		src.Play();
	}
}
