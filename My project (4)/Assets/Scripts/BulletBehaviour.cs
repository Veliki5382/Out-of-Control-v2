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
        float angle = PlayerMovement.rotationAngle;
        if(PlayerMovement.deltaX < 0)
		{
            rb.velocity = new Vector2(-bulletSpeed * Mathf.Cos(angle), bulletSpeed * Mathf.Sin(angle));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle * 180 / Mathf.PI));
		}
		else
		{
            rb.velocity = new Vector2(bulletSpeed * Mathf.Cos(angle), bulletSpeed * Mathf.Sin(angle));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle * 180 / Mathf.PI));
        }
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
