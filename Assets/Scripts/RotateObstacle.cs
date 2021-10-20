using UnityEngine;

// INHERITANCE
public class RotateObstacle : Obstacle
{
    [SerializeField] private float rotationSpeed = 60f;
    private float rotateDirection;

    private void Awake()
    {
        rotateDirection = Random.Range(1, 3);
    }

    // POLYMORPHISM - OVERRIDING
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