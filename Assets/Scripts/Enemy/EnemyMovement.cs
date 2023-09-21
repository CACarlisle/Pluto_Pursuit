using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] Points;
    [SerializeField] private float movementSpeed = 2f;
    private int pointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    //Move the Enemy to each point in the Points list of game objects in order.
    //Reset to start of Points list if final point is reached.
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, movementSpeed * Time.deltaTime);
      
        if (transform.position == Points[pointsIndex].transform.position)
        {
            pointsIndex += 1;
        }

        if (pointsIndex == Points.Length)
        {
            pointsIndex = 0;
        }
    }
}
