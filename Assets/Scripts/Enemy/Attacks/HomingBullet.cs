using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    public float speed = 2f;
    public float rotateSpeed = 200f;
    public int damage = 10;
    public float TTL = 10f;
    public int maxHealth = 30;
	public int currentHealth;

    //Set the player as target, assign health and bullet's rigidbody
    //Destroy game object once the time to live (TTL) expires
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
        Destroy(gameObject, TTL);
    }

    //Use target position and bullet rigidbody to determine direction, rotation, and velocity of bullet
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

    //If the bullet collides with a game object with the tag 'Player', then the player takes damage equal to the bullet's damage
    //If the bullet collides with a game object with the tag 'PlayerBullet', then the bullet takes damage
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
            TakeDamage(damage);
        }
    }

    //Use damage of PlayerBullet to take away the same amount from the homing bullet
    //If health is zero then destory game object.
    void TakeDamage (int damage)
    {
        currentHealth -= damage;

		if (currentHealth <= 0)
		{
			Destroy(gameObject);
		}
    }
}
