using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected float speed = 15f;
    protected float zLowerBound = -75f;

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        CheckBoundary();
    }

    public virtual void MoveDown()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void CheckBoundary()
    {
        if (transform.position.z < zLowerBound)
        {
            Destroy(gameObject);
        }
    }
}