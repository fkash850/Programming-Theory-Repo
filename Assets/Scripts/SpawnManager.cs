using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float spawnRangeX = 3.5f;

    private int startDelay = 2;
    private int repeatRate = 2;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("GenerateRandomObstacle", startDelay, repeatRate);
    }

    private void GenerateRandomObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            int index = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[index], GenerateSpawnPosition(), obstaclePrefab[index].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 randomPos = new Vector3(spawnPosX, 0.75f, 50f);

        return randomPos;
    }
}