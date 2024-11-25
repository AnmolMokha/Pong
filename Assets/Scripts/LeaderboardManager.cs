using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
    }

    public void SaveLeaderboard(Leaderboard leaderboard)
    {
        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(filePath, json);   
    }

    public Leaderboard LoadLeaderboard()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            try
            {
                return JsonUtility.FromJson<Leaderboard>(json);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to deserialize JSON: " + e.Message);
                Debug.LogError("JSON Content: " + json);
            }
        }
        return null;
    }

    public void AddNewScore(string playerName, int score)
    {
        Leaderboard leaderboard = LoadLeaderboard();
        leaderboard.entries.Add(new LeaderboardEntry { playerName = playerName, score = score });

        // Sort by score in descending order
        leaderboard.entries.Sort((a, b) => b.score.CompareTo(a.score));

        SaveLeaderboard(leaderboard);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
