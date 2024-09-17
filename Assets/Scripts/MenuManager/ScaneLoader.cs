using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level2");
    }
    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
    public void PlayFromMain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
