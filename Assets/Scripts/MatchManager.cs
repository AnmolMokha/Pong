using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator LoadSceneAndStartNewGame()
    {
        SceneManager.LoadScene(1);
        yield return null;
        FindObjectOfType<GameManager>().NewGame();
    }

    public IEnumerator LoadSceneAndContinueGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save.txt")) 
        {
            SceneManager.LoadScene(1);
            yield return null;
            FindObjectOfType<GameManager>().ContinueGame();
        }       
    }
}
