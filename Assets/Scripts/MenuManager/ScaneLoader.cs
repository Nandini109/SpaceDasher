using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level2");
        InitializeGame();
    }
    private void InitializeGame()
    {
        Time.timeScale = 1.0f;
        MenuManager.Instance.InitializedMenu();

    }
    public void LoadScene(string name)
    {
        //name = "NextLevel1";
        Time.timeScale = 1.0f;
        //SceneManager.LoadScene(name);
        SceneManager.LoadScene(name);
        
    }
    private void ResetGame()
    {
        PlayGame();
        InitializeGame();
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
