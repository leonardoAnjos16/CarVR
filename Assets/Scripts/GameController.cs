using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void GameOver(string message) {
        // TODO: Change to actual game over logic
        Time.timeScale = 0f;
        Debug.Log("Game Over! " + message);
    }
}
