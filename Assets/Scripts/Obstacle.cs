using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameManager gameManager;
    protected float speed = 20f;
    protected float zLowerBound = -75f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        BoundaryCheck();
        GameOverCheck();
    }

    public virtual void MoveDown()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void BoundaryCheck()
    {
        if (transform.position.z < zLowerBound)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(5);
        }
    }

    public void GameOverCheck()
    {
        if (!gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }
}