using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    static public EventManager instance;

    #region UNITY_EVENTS
    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    #endregion

    #region GAME_MANAGER
    public event Action<bool> OnGameOver;

    public void EventGameOver(bool isVictory) 
    {
        if (OnGameOver != null) OnGameOver(isVictory);
    }
    #endregion

    #region IN_GAME_UI
    public event Action<int, int> OnAmmoChange;
    public event Action<float, float> OnCharacterLifeChange;
    public event Action<int> onRewardEarned;
    public event Action<int> onEnemySuccess;
    public event Action<int> OnWeaponChange;

    public void ActionWeaponChange(int weaponIndex) => OnWeaponChange(weaponIndex);

    public void ActionAmmoChange(int currentAmmo, int maxAmmo) => OnAmmoChange(currentAmmo, maxAmmo);
    public void ActionCharacterLifeChange(float currentLife, float maxLife) => OnCharacterLifeChange(currentLife, maxLife);
    
    public void ActionRewardEarned(int amount) => onRewardEarned(amount);

    public void ActionEnemySuccess(int damage) => onEnemySuccess(damage);


    #endregion
}