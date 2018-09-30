using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class characterController : MonoBehaviour {

	public float thrust;
	public float jump_height;
	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;

	public bool lockstate_off;
	public bool jump_state;
	public bool isGrounded = false;

	public bool Shotgun_eq = false;

	HandsPositions positions;

	public Vector3 LegOffsetR;
	public Vector3 LegOffsetL;

	Transform LeftLeg;
	Transform RightLeg;


	Rigidbody rb;
	Animator anim;

	public GameObject Shotgun;

	void Start() {
		lockstate_off = false;
		Cursor.lockState = CursorLockMode.Locked;

		rb = gameObject.GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();

		RightLeg = anim.GetBoneTransform (HumanBodyBones.RightUpperLeg);
		LeftLeg = anim.GetBoneTransform (HumanBodyBones.LeftUpperLeg);

	}

	void Update ()
	{
		if (lockstate_off == false && Input.GetKeyDown ("escape")) {
			lockstate_off = true;
			Cursor.lockState = CursorLockMode.None;
		} else if (lockstate_off == true && Input.GetKeyDown ("escape")) {
			lockstate_off = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		Moving ();
		Equipment ();


		if (Shotgun_eq == true) { 
			Shotgun.SetActive (true);
		}

		if (jump_state == true) {
			anim.SetBool("Landed", false);
		} else anim.SetBool ("Landed", true);

	}


	 void Moving ()
	{
		float moving_forward_backward = Input.GetAxis ("Vertical") * thrust;
		float strafe = Input.GetAxis ("Horizontal") * thrust;

		bool running = Input.GetKey (KeyCode.LeftShift);

		moving_forward_backward *= Time.deltaTime;
		strafe *= Time.deltaTime;

		transform.Translate (strafe, 0, moving_forward_backward);

		if (Input.GetButtonDown ("Jump") && isGrounded && jump_state == false) {
			anim.SetTrigger ("JumpTrigger");
			jump_state = true;
			rb.AddForce (new Vector3 (0, jump_height, 0), ForceMode.Impulse);

		}

		if (Input.GetKey (KeyCode.W)) {
			anim.SetFloat ("speedPercent", 0.0f, speedSmoothTime, Time.deltaTime);
		} else {
			anim.SetFloat ("speedPercent", .25f, speedSmoothTime, Time.deltaTime);  
		}
		if (Input.GetKey (KeyCode.S)) {
			anim.SetFloat ("speedPercent", .5f, speedSmoothTime, Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {

			anim.SetFloat ("speedPercent", .75f, speedSmoothTime, Time.deltaTime);

			if (Input.GetKey (KeyCode.A)) {

				anim.SetFloat ("strafingPercent", 0f, speedSmoothTime, Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.D)) { 

				anim.SetFloat ("strafingPercent", 1f, speedSmoothTime, Time.deltaTime);
			}
		}  
	}

	public void Equipment ()
	{

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Shotgun_eq = true;
			anim.SetBool("ShootGun_eq", true);
			positions.enabled = true;
		}
	}
}
