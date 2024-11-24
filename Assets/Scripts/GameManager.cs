using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerScore;

    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;

    private bool isGameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
            }
            else
            {
                pauseScreen.SetActive(true);
            }
        }
    }

    public void NewGame()
    {
        NewRound();
        playerScore = 0;
        playerScoreText.text = playerScore.ToString();
    }

    public void ContinueGame()
    {
        Load();
        NewRound();
    }

    public void NewRound()
    {
        Time.timeScale = 1f;

        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();

        ball.currentSpeed = ball.baseSpeed;

        isGameOver = false;

        CancelInvoke();
        Invoke("StartRound", 1f);
    }

    private void StartRound()
    {
        ball.ServeBall();
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);
        NewRound();
    }

    public void OnComputerScored()
    {
        Time.timeScale = 0f;
        DeleteSave();
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = playerScore.ToString();
    }

    public void Save()
    {
        Vector2 ballPosition = ball.gameObject.transform.position;
        Vector2 ballVelocity = ball.gameObject.GetComponent<Rigidbody2D>().velocity;
        float ballSpeed = ball.currentSpeed;
        Vector2 playerPaddlePosition = playerPaddle.gameObject.transform.position;
        Vector2 computerPaddlePosition = computerPaddle.gameObject.transform.position;
        int playerScore = this.playerScore;

        SaveObject saveObject = new SaveObject
        {
            //ballPosition = ballPosition,
            //ballVelocity = ballVelocity,
            //ballSpeed = ballSpeed,
            //playerPaddlePosition = playerPaddlePosition,
            //computerPaddlePosition = computerPaddlePosition,
            playerScore = playerScore,
        };

        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.persistentDataPath + "/save.txt", json);
        Debug.Log("Saved!");
        Debug.Log("Save file path: " + Application.persistentDataPath);
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "/save.txt");
            Debug.Log("Loaded: " + saveString);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            //ball.gameObject.transform.position = saveObject.ballPosition;
            //ball.gameObject.GetComponent<Rigidbody2D>().velocity = saveObject.ballVelocity;
            //ball.currentSpeed = saveObject.ballSpeed;
            //playerPaddle.gameObject.transform.position = saveObject.playerPaddlePosition;
            //computerPaddle.gameObject.transform.position = saveObject.computerPaddlePosition;
            playerScore = saveObject.playerScore;

            Time.timeScale = 1f;
            SetPlayerScore(playerScore);
            isGameOver = false;
        }
        else
        {
            Debug.Log("No Save File Found!");
        }
    }

    public void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            File.Delete(Application.persistentDataPath + "/save.txt");
        }
        else
        {
            Debug.Log("No save file to delete.");
        }
    }

    private class SaveObject
    {
        //public Vector2 ballPosition;
        //public Vector2 ballVelocity;
        //public float ballSpeed;
        //public Vector2 playerPaddlePosition;
        //public Vector2 computerPaddlePosition;
        public int playerScore;
    }
}
