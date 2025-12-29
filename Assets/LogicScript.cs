using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public int highScore = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public AudioSource scoreSound;
    void Start()
    {
        Time.timeScale = 0f;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best: " + highScore.ToString();
    }
    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore+= scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreSound.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        highScoreText.text = "Best: " + highScore.ToString();
    }
    public void StartGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}