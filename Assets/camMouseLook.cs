using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camMouseLook : MonoBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV;

	public float sensitivity = 5.0f;
	public float smooth = 2.0f;

	public GameObject player;
	public GameObject Chest;

	void Start ()
	{

	}

	void Update ()
	{

		var mouseMove = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		mouseMove = Vector2.Scale(mouseMove, new Vector2(sensitivity * smooth, sensitivity * smooth));
		smoothV.x = Mathf.Lerp(smoothV.x, mouseMove.x, 1f / smooth);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseMove.y, 1f / smooth);

		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90f,90f);

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

	}
}
