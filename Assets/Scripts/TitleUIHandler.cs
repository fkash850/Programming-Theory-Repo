using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class TitleUIHandler : MonoBehaviour
{
    public void StartMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitApp()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit(); // Quit Unity player if not in UnityEditor
        }
    }
}