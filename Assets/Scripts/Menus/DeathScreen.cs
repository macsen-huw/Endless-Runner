using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    private GameLogic gameManager;
    public Text scoreText;
    public Text highScoreText;

    public GameObject scoreCanvas;

    private void Start()
    {
        this.gameObject.SetActive(false);

        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameLogic>();
    }

    public void Death()
    {
        //Stop the game
        Time.timeScale = 0f;

        //Check whether the user has a new high score
        int currentScore = gameManager.GetScore();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        //Save the new high score (if there is one)
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore = currentScore;
        }

        //Set the correct texts
        scoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();

        //Display the death screen
        this.gameObject.SetActive(true);

        //Remove the old score text
        scoreCanvas.SetActive(false);
    }

    //Play again
    public void Replay()
    {
        SceneManager.LoadScene("MainScene");
    }

    //Back to Main Menu
    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
    }


}
