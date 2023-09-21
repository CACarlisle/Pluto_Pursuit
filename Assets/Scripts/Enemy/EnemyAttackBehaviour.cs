using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    public Transform firePoint;
    public GameObject HomingBullet;

    EnemyBulletHell[] bullets;

    public float Buffer;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        bullets = transform.GetComponentsInChildren<EnemyBulletHell>();
    }

    //After 2 rounds of homing bullets, then fire 3 rounds of bullet hell
    //Buffer 3 seconds between each round
    void Update()
    {
        Buffer += Time.deltaTime;

        if (Buffer > 3)
        {
            Buffer = 0;

            if (counter % 5 < 2) 
            {
                ShootHomingBullet();
            }

            else
            {
                foreach (EnemyBulletHell b in bullets)
                {
                    b.Shoot();
                }
            }

            counter++;
        }
    }
    
    //Method to fire a homing bullet
    void ShootHomingBullet()
    {
        Instantiate(HomingBullet, firePoint.position, Quaternion.identity);
    }
}
