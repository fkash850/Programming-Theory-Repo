using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    private float spawnRate = 2f;
    private float spawnRangeX = 3.5f;

    public GameObject gameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score = 0;

    public Button menuButton;
    public Button restartButton;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnOverTime());
        // spawnRate /= difficulty;

        score = 0;
        UpdateScore(0);

        gameOver.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }

    IEnumerator SpawnOverTime()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index], GenerateSpawnPosition(), obstacles[index].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 randomPos = new Vector3(spawnPosX, 0.75f, 50f);

        return randomPos;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOver.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}