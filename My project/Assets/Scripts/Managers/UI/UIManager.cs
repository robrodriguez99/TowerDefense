using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
   // Properties
    [SerializeField] private Image _healthBar;

    // [SerializeField] private Text _scoreText;

     
    // Methods

    private void Start()
    {
        EventManager.instance.OnCharacterLifeChange += OnCharacterLifeChange;
       
    }
    private void OnCharacterLifeChange(float currentLife, float maxLife)
    {
        _healthBar.fillAmount = currentLife / maxLife;
    }

}
