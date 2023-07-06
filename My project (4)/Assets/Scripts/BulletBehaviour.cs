using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public PlayerMovement playerGun;
    Rigidbody2D rb;
    float bornTime;
    public float lifeTime;
    public float bulletSpeed;

    void Start()
    {
        bornTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed * Mathf.Cos(PlayerMovement.rotationAngle), bulletSpeed * Mathf.Sin(PlayerMovement.rotationAngle));
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time - bornTime >= lifeTime)
		{
            Destroy(gameObject);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}
}
