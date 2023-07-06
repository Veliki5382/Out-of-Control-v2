using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Vector2 orientation;
	Rigidbody2D rb;
	public float moveSpeed;
	public GameObject gun;
	float rotationAngle;
	public Vector3 gunOffset;
	public GameObject camera;

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
		gun.transform.position = transform.position + gunOffset;

		float deltaY = Input.mousePosition.y - transform.position.y - Screen.height / 2;
		float deltaX = Input.mousePosition.x - transform.position.x - Screen.width / 2;
		if (deltaX < 0)
		{
			rotationAngle = Mathf.Atan2(deltaY, -deltaX) * 180 / Mathf.PI;
			gun.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, rotationAngle));
		}
		else
		{
			rotationAngle = Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI;
			gun.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotationAngle));
		}
		Debug.DrawLine(Input.mousePosition +camera.transform.position, camera.transform.position, Color.red, 2, false);
	}
}
