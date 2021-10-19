using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RotateObstacle : Obstacle
{
    [SerializeField] private float rotationSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        CheckBoundary();
    }

    // POLYMORPHISM
    public override void MoveDown()
    {
        base.MoveDown();
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}