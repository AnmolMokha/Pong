using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
