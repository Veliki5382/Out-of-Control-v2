using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Vector2 orientation;
	Rigidbody2D rb;
	public float moveSpeed;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");
		orientation = new Vector2(moveX, moveY).normalized;
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(orientation.x * moveSpeed, orientation.y * moveSpeed);
	}
}
