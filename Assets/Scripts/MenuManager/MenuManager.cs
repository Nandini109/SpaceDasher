using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    private InputAction Pause;//when player esc key  input ,pause menu will show
    private PlayerControls playerControls;

    private SceneLoader sceneLoader;
  
    [SerializeField] private GameObject pauseMenuPerfab;
    [SerializeField] private GameObject dieMenuPerfab;
    [SerializeField] private GameObject winMenuPerfab;

    private GameObject pauseMenu;
    private GameObject dieMenu;
    private GameObject winMenu;

   

    public void InitializedMenu()
    {
        if (pauseMenu == null)
        {
            pauseMenu = Instantiate(pauseMenuPerfab);
            pauseMenu.SetActive(false);
        }
        if (dieMenu == null)
        {
            dieMenu = Instantiate(dieMenuPerfab);
            dieMenu.SetActive(false);
        }
        if(winMenu == null)
        {
            winMenu = Instantiate(winMenuPerfab);
            winMenu.SetActive(false);
        }
    }
  
    private void Awake()
    {
        InitializedMenu();
        
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }

        playerControls = new PlayerControls();
        pauseMenu = pauseMenuPerfab.gameObject;

        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        playerControls.MenuControl.Pause.performed += ctx => PauseGame();

    }

    private void PauseGame()
    {
        if (pauseMenu.activeSelf == false)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            BackToGame();
        }
        
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
        pauseMenu.SetActive(false);
        
    }

    public void ShowDieMenu()
    {
        
        if (dieMenu == null)
        {
            dieMenu = Instantiate(dieMenuPerfab);
           
        }
        dieMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWinMenu()
    {

        if (winMenu == null)
        {
            winMenu = Instantiate(winMenuPerfab);

        }
        winMenu?.SetActive(true);
    }

    private void ToMainMenu()
    {
        sceneLoader.PlayGame();
    }

}
