using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    private GameLogic gameManager;
    private bool isDead;
    public Text scoreText;
    public Text highScoreText;

    private void Start()
    {
        isDead = false;
        this.gameObject.SetActive(false);

        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameLogic>();
    }

    public void Death()
    {
        //Stop the game
        Time.timeScale = 0f;

        isDead = true;

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
    }

    //Play again
    public void Replay()
    {
        SceneManager.LoadScene("MainScene");
    }


}
