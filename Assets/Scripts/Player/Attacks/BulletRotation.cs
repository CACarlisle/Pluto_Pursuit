using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    [SerializeField] float rotSpeed;

    //Consistently rotate the game object (used for player bullet)
    void Update()
    {
        transform.Rotate (new Vector3(0, 0, -rotSpeed));
    }
}
