using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardInitializer : MonoBehaviour
{
    void Start()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        if (!File.Exists(filePath))
        {
            Leaderboard leaderboard = new Leaderboard();
            string json = JsonUtility.ToJson(leaderboard, true);
            File.WriteAllText(filePath, json);

            Debug.Log("Leaderboard initialized at: " + filePath);
        }
    }
}
