using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	static public float rotationAngle;
	static public float deltaX, deltaY;
	
	Vector2 orientation;
	Rigidbody2D rb;
	public float moveSpeed;
	public GameObject gun;
	public GameObject bulletSpawner;
	public Vector3 gunOffset;
	public Vector3 bulletSpawnerOffset;
	public GameObject camera;
	public float delayFactor;
	public Animator animator;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		transform.position = Vector3.zero;
		gunOffset = new Vector3(0.1f, 0.1f, -2f);
		bulletSpawnerOffset = new Vector3(0.6f, 0.09f, -4f);
	}

	void Update()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");
		orientation = new Vector2(moveX, moveY).normalized;
        animator.SetBool("isMoving", moveX != 0 || moveY != 0);

		if(moveX < 0)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
		}
		else
		{
			transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
		}

        gun.transform.position = transform.position + gunOffset;
		if (deltaX < 0)
		{

			float finalX = bulletSpawnerOffset.x * Mathf.Cos(rotationAngle) + bulletSpawnerOffset.y * Mathf.Sin(rotationAngle);
			float finalY = bulletSpawnerOffset.x * Mathf.Sin(rotationAngle) - bulletSpawnerOffset.y * Mathf.Cos(rotationAngle);
			bulletSpawner.transform.position = gun.transform.position + new Vector3(-finalX, finalY, bulletSpawnerOffset.z);
		}
		else
		{

			float finalX = bulletSpawnerOffset.x * Mathf.Cos(rotationAngle) + bulletSpawnerOffset.y * Mathf.Sin(rotationAngle);
			float finalY = bulletSpawnerOffset.x * Mathf.Sin(rotationAngle) - bulletSpawnerOffset.y * Mathf.Cos(rotationAngle);
			bulletSpawner.transform.position = gun.transform.position + new Vector3(finalX, finalY, bulletSpawnerOffset.z);
		}

		
		
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(orientation.x * moveSpeed, orientation.y * moveSpeed);
		
		deltaY = Input.mousePosition.y - transform.position.y - Screen.height / 2;
		deltaX = Input.mousePosition.x - transform.position.x - Screen.width / 2;
		if (deltaX < 0)
		{
			rotationAngle = Mathf.Atan2(deltaY, -deltaX);
			gun.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, rotationAngle * 180 / Mathf.PI));
		}
		else
		{
			rotationAngle = Mathf.Atan2(deltaY, deltaX);
			gun.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotationAngle * 180 / Mathf.PI));
		}
		gunOffset = new Vector3(deltaX / 100 * delayFactor, gunOffset.y, gunOffset.z);
		//Debug.DrawLine(Input.mousePosition +camera.transform.position, camera.transform.position, Color.red, 2, false);
	}
}
