using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private SceneLoader sceneLoader;
    private InputAction Pause;
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        sceneLoader = new SceneLoader();
        Debug.Log("playerControls is" + playerControls);
        Debug.Log("sceneLoader is" + sceneLoader);
        if (pauseMenu.activeSelf)
        {
           
            playerControls.MenuControl.Pause.performed += ctx => PauseGame();
        }
        else
        {
            BackToGame();
        }

    }

    private void PauseGame()
    {
        Debug.Log("pause menu show");
        Time.timeScale = 0f;
        Debug.Log("pause game" );
        pauseMenu.SetActive(true);
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void BackToGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu?.SetActive(false);
        Debug.Log("pause close");
    }
    private void ResetGame()
    {
        sceneLoader.PlayGame();
    }
    private void ToMainMenu()
    {
        sceneLoader.PlayGame();
    }

}
