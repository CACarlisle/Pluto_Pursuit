using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 20f;
	public int damage = 40;
	public float TTL = 0.1f;
	public Rigidbody2D rb;
	public GameObject impactEffect;

    //Destroy game object once the time to live (TTL) expires
    //Determine bullets velocity
    void Start()
    {
        rb.velocity = transform.right * speed;
		Destroy(gameObject, TTL);
    }

    //If the bullet collides with a game object with the tag 'Enemy', then the enemy takes damage equal to the bullet's damage
    //If the bullet collides with a game object with the tag 'EnemyBullet', then the bullet is destroyed
    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.tag == "Enemy")
		{
			EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
			
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			} 

			Destroy(gameObject);
		}

		if (collision.collider.gameObject.tag == "EnemyBullet")
		{
			Destroy(gameObject);
		}
	}
}
