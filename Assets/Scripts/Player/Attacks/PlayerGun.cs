using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform firePoint;
	public GameObject RegularBullet;
    public GameObject ChargeBullet;

    //If left mouse button pressed fire regular bullet
    //If right mouse button pressed fire charge bullet (currently not implimented)
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
		{
			Instantiate(RegularBullet, firePoint.position, firePoint.rotation);
		} 

        if (Input.GetButtonDown("Fire2"))
		{
			Instantiate(ChargeBullet, firePoint.position, firePoint.rotation);
		} 
    }
}
