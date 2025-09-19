using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // makes the scoremanger public aswell as the scoretext and highscore text 
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    // starts the score and highscore on zero
    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //counts the highscore of the player aswell as the points the player recived in that round 
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + "POINTS";
        highscoreText.text = "HIGHSCORE:" + highscore.ToString();
    }
    // remebers the value of the players highscore and resets the points collected that round
    public void Addpoint()
    {
        score += 1;
        scoreText.text = score.ToString() + "POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
}

