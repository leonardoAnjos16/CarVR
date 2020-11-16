using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private int score = 0;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;

    void Start(){
        scoreText.text = "Score: 0";

        if(PlayerPrefs.HasKey("highscore")){
            highScore = PlayerPrefs.GetInt("highscore");
            highScoreText.text = "High Score: " +  highScore;

        }else{
              highScoreText.text = "High Score: 0";
              highScore = 0;
        }
    }

    void Update(){
        score = score + 1;
        scoreText.text = "Score: " + score;
    }


    public void GameOver(string message) {
        // TODO: Change to actual game over logic
        Time.timeScale = 0f;
        Debug.Log("Game Over! " + message);
        

        
    }

    private void CheckHighScore(){
       if(score>highScore){
           PlayerPrefs.SetInt("highscore", score);
       }
    }
}
