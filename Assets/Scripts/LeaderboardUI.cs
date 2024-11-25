using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private LeaderboardPlayerEntry leaderboardEntry;

    void Start()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Leaderboard leaderboard = JsonUtility.FromJson<Leaderboard>(json);

            foreach (var entry in leaderboard.entries)
            {
                //leaderboardText.text += $"{entry.playerName}: {entry.score}\n";

                LeaderboardPlayerEntry entryObject = Instantiate(leaderboardEntry, this.transform);
                entryObject.playerNameText.text = entry.playerName;
                entryObject.playerScoreText.text = entry.score.ToString();
            }
        }    
    }
}
