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
    [SerializeField] private TextMeshProUGUI _gameoverMessage;
    [SerializeField] public GameObject EndGameScene;


    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;

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
        // Time.timeScale = 0; // This "pauses" the game by making everything happen at "0 speed"
        EndGameScene.SetActive(true);
    }
}
