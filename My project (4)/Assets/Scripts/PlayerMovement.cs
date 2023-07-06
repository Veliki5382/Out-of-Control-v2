using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Vector2 orientation;
	Rigidbody2D rb;
	public float moveSpeed;
	public GameObject kita;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");
		orientation = new Vector2(moveX, moveY).normalized;
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(orientation.x * moveSpeed, orientation.y * moveSpeed);
		Quaternion rotation = Quaternion.identity;
		rotation.eulerAngles = new Vector3(0.0f, 0.0f, orientation.x * 90 + orientation.y * 90);
		kita.transform.rotation = rotation;
	}
}
