using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RotateObstacle : Obstacle
{
    [SerializeField] private float rotationSpeed = 50;
    private float rotateDirection;

    private void Awake()
    {
        rotateDirection = Random.Range(1, 3);
    }

    // POLYMORPHISM
    public override void MoveDown()
    {
        base.MoveDown();

        if (rotateDirection == 1)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
}