using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour {

	CapsuleCollider col;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		col = GetComponent<CapsuleCollider>();
		Debug.Log(col);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (col == null) {
			Destroy(enemy, 10f);
		}
	}
}
