using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;

	public GameObject deathEffect;

	void Start()
	{
		currentHealth = maxHealth;
	}

	//Use damage of bullet to take away the same amount from the enemy health
	public void TakeDamage (int damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	//If health is zero then play deathEffect animation and destory game object.
	void Die ()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
