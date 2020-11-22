using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string scene;

    public void LoadNewScene(){
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
