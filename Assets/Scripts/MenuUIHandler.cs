using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerInput;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance != null && !MainManager.Instance.BestPlayer.Equals(""))
        {
            highScoreText.text = $"Current High Score: {MainManager.Instance.BestPlayer} - {MainManager.Instance.HighScore}";
            playerInput.text = MainManager.Instance.CurrentPlayer;
        }
        else
        {
            highScoreText.text = "Current High Score: 0";
            playerInput.text = MainManager.Instance.CurrentPlayer;
        }
    }

    // Load main scene on start button click
    public void StartMain()
    {
        MainManager.Instance.SavePlayer(playerInput.text);
        SceneManager.LoadScene(2);
    }

    // Exit application on exit button click
    public void BackToTitle()
    {
        MainManager.Instance.SavePlayer(playerInput.text);
        SceneManager.LoadScene(0);
    }
}