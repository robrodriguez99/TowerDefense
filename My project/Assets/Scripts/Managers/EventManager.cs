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
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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
    public event Action<int> onEnemySuccess;
    public event Action<int> OnWeaponChange;
    public event Action<int> onRewardEarned;

    public event Action<int> OnGoldChange;

    public void ActionGoldChange(int amount) 
    {
        OnGoldChange?.Invoke(amount);
    }

    public void ActionWeaponChange(int weaponIndex) 
    {   
        OnWeaponChange?.Invoke(weaponIndex);
    }   
    public void ActionAmmoChange(int currentAmmo, int maxAmmo) 
    {
        OnAmmoChange?.Invoke(currentAmmo, maxAmmo);
    }

    public void ActionCharacterLifeChange(float currentLife, float maxLife) 
    {
        OnCharacterLifeChange?.Invoke(currentLife, maxLife);
    }

    public void ActionEnemySuccess(int damage) 
    {
        onEnemySuccess?.Invoke(damage);
    }

    public void ActionRewardEarned(int amount) 
    {
        onRewardEarned?.Invoke(amount);
    }

    



    #endregion
}