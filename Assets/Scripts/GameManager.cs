using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    private float spawnRate = 1.25f;
    private float spawnRangeX = 3.5f;

    public GameObject gameOver;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private string player;
    public int score = 0;

    public Button menuButton;
    public Button restartButton;
    public bool isGameActive;

    public List<Material> skyboxes;
    private Skybox skybox;

    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadPlayer();
        player = MainManager.Instance.CurrentPlayer;
        playerText.SetText($"Player: {player}");
        
        StartGame();
        
        skybox = GameObject.Find("Main Camera").GetComponent<Skybox>();
        int index = Random.Range(0, skyboxes.Count);
        skybox.material = skyboxes[index];
    }

    public void StartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnOverTime());
        
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

    // ABSTRACTION
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // ABSTRACTION
    public void GameOver()
    {
        isGameActive = false;
        gameOver.gameObject.SetActive(true);

        // ENCAPSULATION
        if (score > MainManager.Instance.HighScore)
        {
            MainManager.Instance.SavePlayer(player, player, score);
            highScoreText.gameObject.SetActive(true);
            highScoreText.SetText($"New High Score: {player} - {score}");
        }
        else
        {
            MainManager.Instance.SavePlayer(player);
        }
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