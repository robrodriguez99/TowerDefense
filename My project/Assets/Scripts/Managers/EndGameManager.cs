using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;
using UnityEngine.UI;


public class EndGameManager : MonoBehaviour
{

    [SerializeField] private Image _background;
    [SerializeField] private Sprite _victorySprite;
    [SerializeField] private Sprite _defeatSprite;

    // Start is called before the first frame update
    void Start()
    {
        _background.sprite = GlobalVictory.Instance.IsVictory ? _victorySprite : _defeatSprite;
    }

    public void ActionMainMenu() => SceneManager.LoadScene(UnityScenes.MainMenu.ToString());
}
