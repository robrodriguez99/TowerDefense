using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
   // Properties
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _weapon;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private List<Sprite> _weaponSprites;

    [SerializeField] private TextMeshProUGUI _goldText;

    // [SerializeField] private Text _scoreText;

     
    // Methods

    private void Start()
    {
        EventManager.instance.OnCharacterLifeChange += OnCharacterLifeChange;
        EventManager.instance.OnWeaponChange += OnWeaponChange;
        EventManager.instance.OnAmmoChange += OnAmmoChange;
        EventManager.instance.OnGoldChange += OnGoldChange;
       
    }
    private void OnCharacterLifeChange(float currentLife, float maxLife)
    {
        _healthBar.fillAmount = currentLife / maxLife;
    }

    private void OnWeaponChange(int weaponIndex)
    {
        _weapon.sprite = _weaponSprites[weaponIndex];
    }

    private void OnAmmoChange(int currentAmmo, int maxAmmo)
    {
        _ammoText.text = $"{currentAmmo}" + "/" + $"{maxAmmo}";
    }

    private void OnGoldChange(int amount)
    {
        Debug.Log("Reward earned at gold change UiManager with amount: " + amount);
        _goldText.text = $"{amount}";
    }


}
