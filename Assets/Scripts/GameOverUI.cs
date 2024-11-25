using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameObject.SetActive(false);
    }

    public void Retry()
    {
        gameManager.NewGame();
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void SubmitScoreAndQuit()
    {
        FindObjectOfType<GameManager>().SubmitScore();
        SceneManager.LoadScene(0);
    }
}
