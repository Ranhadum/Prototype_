using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTarget_rocket : MonoBehaviour {

public GameObject VFX;


	public AudioClip boom_clip;

	Transform sound_transform;
	Rigidbody rb;
	MeshRenderer mesh;
	AudioSource src;
	TrailRenderer trail;


	void Update() {
		sound_transform = GetComponent<Transform>();
		src = GetComponent<AudioSource>();
		mesh = GetComponent<MeshRenderer>();
		rb = GetComponent<Rigidbody>();
		src.clip = boom_clip;
	}

	void OnCollisionEnter (Collision col)
	{
		src.Play();
		VFX.SetActive (false);
		mesh.enabled = false;
		rb.useGravity = false;
		rb.isKinematic = true;

		Destroy(gameObject, 0.8f);
	}
	
}
