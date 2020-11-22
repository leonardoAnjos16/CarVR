using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private float scoreAux = 0;
    private int highScore;

    public Text scoreText;

    // Start is called before the first frame update
    void Start() {
        scoreText.text = "Score: 0";
        if (PlayerPrefs.HasKey("highscore")) {
            highScore = PlayerPrefs.GetInt("highscore");
        } else {
            highScore = 0;
        }
    }

    // Update is called once per frame
    void Update() {
        scoreAux += Time.deltaTime * 10;
        score = (int) scoreAux; 
        scoreText.text = "Score: " + score.ToString("D8");
    }

    public void GameOver(string message) {
        // TODO: Change to actual game over logic
        Time.timeScale = 0f;
        Debug.Log("Game Over! " + message);
    }

    private void UpdateHighScore() {
       if (score > highScore){
           PlayerPrefs.SetInt("highscore", score);
       }
    }
}
