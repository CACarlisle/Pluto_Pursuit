using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
	public int damage = 40;
	public float TTL = 2f;

	public Rigidbody2D rb;
	public GameObject impactEffect;

	public Vector2 direction = new Vector2 (1, 0);
	public Vector2 velocity;

	//Destroy game object once the time to live (TTL) expires
	//Determine bullets velocity
    void Start()
    {
        rb.velocity = direction * speed;
		Destroy(gameObject, TTL);
    }

    //If the bullet collides with a game object with the tag 'Player', then the player takes damage equal to the bullet's damage
    //If the bullet collides with a game object with the tag 'PlayerBullet', then the bullet is destroyed
    void OnCollisionEnter2D(Collision2D collision)
   {
		if (collision.collider.gameObject.tag == "Player")
		{
			PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
			
			if (player != null)
			{
				player.TakeDamage(damage);
			} 

			Destroy(gameObject);
		}

		if (collision.collider.gameObject.tag == "PlayerBullet")
		{
			Destroy(gameObject);
		}
   }
   
}
