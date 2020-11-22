using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private float scoreAux = 0;
    private int highScore;

    public Canvas gameOverCanvas;
    public Text[] gameOverTexts;
    public Text newHighScoreText;
    public Text mainScoreText;

    // Start is called before the first frame update
    void Start() {
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
        mainScoreText.text = "Score: " + score.ToString("D8");
    }

    public void GameOver(string description) {
        // TODO: Change to actual game over logic
        Time.timeScale = 0f;

        if (score > highScore) {
            UpdateHighScore();
            newHighScoreText.gameObject.SetActive(true);
        }

        gameOverTexts[0].text = description;
        gameOverTexts[1].text = "Score: " + score;
        gameOverTexts[2].text = "High Score: " + highScore;
        gameOverCanvas.gameObject.SetActive(true);
    }

    private void UpdateHighScore() {
        highScore = score;
        PlayerPrefs.SetInt("highscore", score);
    }
}
