using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class EnemyBulletHell : MonoBehaviour
{ 
    public EnemyBullet bullet;
    Vector2 direction;

    //Determine the direction of the bullets
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
    }

    //Method used to fire bullet hell round
    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        EnemyBullet goBullet = go.GetComponent<EnemyBullet>();
        goBullet.direction = direction;
    }
}
