using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsPositions : MonoBehaviour {

	public Transform RightHandPos;
	public Transform LeftHandPos;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnAnimatorIK() {
		anim.SetIKPosition(AvatarIKGoal.RightHand, RightHandPos.position);

		anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 1f);

		anim.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandPos.position);

		anim.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1f);
	}
}
