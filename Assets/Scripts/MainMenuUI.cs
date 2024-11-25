using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void NewGame()
    {
        MatchManager.Instance.StartCoroutine(MatchManager.Instance.LoadSceneAndStartNewGame());
    }

    public void ContinueGame()
    {
        MatchManager.Instance.StartCoroutine(MatchManager.Instance.LoadSceneAndContinueGame());
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
