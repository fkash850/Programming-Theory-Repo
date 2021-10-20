using System.Collections;
using UnityEngine;

// INHERITANCE
public class ScaleObstacle : Obstacle
{
    private int minScale = 5;
    private int maxScale = 15;
    private int growFactor = 1;

    // POLYMORPHISM - OVERRIDING
    public override void MoveDown()
    {
        base.MoveDown();
        StartCoroutine(ScaleOverTime(2));
    }

    IEnumerator ScaleOverTime(float waitTime)
    {
        float timer = 0;

        // While the gameObject is active
        while (gameObject)
        {
            // Scale only the x axis over time
            while (maxScale > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += Vector3.right * growFactor * Time.deltaTime;
                yield return null;
            }

            // Reset the timer
            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (minScale < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += Vector3.left * growFactor * Time.deltaTime;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}