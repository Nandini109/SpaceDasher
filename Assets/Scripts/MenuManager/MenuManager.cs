using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    [SerializeField] private PlayerControls playerControls;
    private SceneLoader sceneLoader;
    private InputAction Pause;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject dieMenu;
    [SerializeField] private GameObject winMenu;


    private void Start()
    {
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        dieMenu.SetActive(false);

      
    }

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
           // Destroy(gameObject); 
        }

        playerControls = new PlayerControls();
       
       
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
    public void ShowDieMenu()
    {
        dieMenu?.SetActive(true);
    }
    public void ShowWinMenu()
    {
        winMenu?.SetActive(true);
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
