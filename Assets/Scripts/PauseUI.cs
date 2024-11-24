using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button saveAndQuitButton;

    private GameManager gameManager;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

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

    public void SaveAndQuit()
    {
        gameManager.Save();
        SceneManager.LoadScene(0);
    }
}
