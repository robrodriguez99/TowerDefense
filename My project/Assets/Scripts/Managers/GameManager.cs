using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private int  _wavesCleared = 0;
    [SerializeField] private TextMeshProUGUI _gameoverMessage;
    [SerializeField] public GameObject EndGameScene;
    [SerializeField] public GameObject pauseMenu;

    [SerializeField] public int totalWaves = 5;

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
        EventManager.instance.OnWaveCleared += OnWaveCleared;
        EventManager.instance.OnPauseRequested += OnPauseRequested;
        EventManager.instance.OnResumeRequested += OnResumeRequested;
        _gameoverMessage.text = string.Empty;
    }

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;
        // GlobalVictory.Instance.IsVictory = isVictory;

        _gameoverMessage.text = isVictory ? "Victory" : "Defeat";
        _gameoverMessage.color = isVictory ? Color.cyan : Color.red;

        LoadEndgameScene();
    }

    private void LoadEndgameScene() {
        Time.timeScale = 0; // This "pauses" the game by making everything happen at "0 speed"
        EndGameScene.SetActive(true);
         // Make the mouse cursor visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
    }

    public void OnPauseRequested()
    {
        Time.timeScale = 0; // This "pauses" the game by making everything happen at "0 speed"
        pauseMenu.SetActive(true);

        // Make the mouse cursor visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // this line will unlock the cursor if it was locked.
    }

    public void OnResumeRequested()
    {
        Time.timeScale = 1; // This makes the game run at normal speed again
        pauseMenu.SetActive(false);

        // Hide the mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // this line will lock the cursor again when the game is unpaused.
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1; 
        // Stop all Coroutines before loading the new scene.
        StopAllCoroutines();
        SceneManager.LoadScene(UnityScenes.MainMenu.ToString());
    }

    private void OnWaveCleared()
    {
        _wavesCleared++;
        if (_wavesCleared == totalWaves) OnGameOver(true);
    }

    public void ActionExit() => Application.Quit();
}
