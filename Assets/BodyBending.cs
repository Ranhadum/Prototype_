using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BodyBending : MonoBehaviour {

	public Transform lookPosition;
	public Vector3 OffsetChest;
	public Vector3 OffsetHead;

	Animator anim;
	Transform spine;
	Transform head;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		spine = anim.GetBoneTransform (HumanBodyBones.Chest);
		head = anim.GetBoneTransform (HumanBodyBones.Head);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		spine.LookAt(lookPosition.position);
		spine.rotation = spine.rotation * Quaternion.Euler (OffsetChest);
		head.LookAt(lookPosition.position);
		head.rotation = head.rotation * Quaternion.Euler (OffsetHead);
	}

}
