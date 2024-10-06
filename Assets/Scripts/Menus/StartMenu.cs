using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    public Text highScoreText;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        //Just to ensure there is no funny business when switching scenes
        Time.timeScale = 1.0f;

        //Get the high score and display it
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();

    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }


}
