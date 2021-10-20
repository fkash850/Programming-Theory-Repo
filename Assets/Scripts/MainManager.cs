using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string CurrentPlayer = "";
    public string BestPlayer = "";
    public int Difficulty = 1;
    public int HighScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayer();
    }

    [System.Serializable]
    class SaveData
    {
        public string CurrentPlayer;
        public string BestPlayer;
        public int Difficulty;
        public int HighScore;
    }

    public void SavePlayer(string player)
    {
        SaveData data = new SaveData();
        data.CurrentPlayer = player;
        data.BestPlayer = BestPlayer;
        data.Difficulty = Difficulty;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SavePlayer(int difficulty)
    {
        SaveData data = new SaveData();
        data.CurrentPlayer = CurrentPlayer;
        data.BestPlayer = BestPlayer;
        data.Difficulty = difficulty;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SavePlayer(string player, string bestPlayer, int score)
    {
        SaveData data = new SaveData();
        data.CurrentPlayer = player;
        data.BestPlayer = bestPlayer;
        data.Difficulty = Difficulty;
        data.HighScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentPlayer = data.CurrentPlayer;
            BestPlayer = data.BestPlayer;
            Difficulty = data.Difficulty;
            HighScore = data.HighScore;
        }
    }
}