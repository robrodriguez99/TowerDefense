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

    #endregion

    #region IN_GAME_UI
    public event Action<int, int> OnAmmoChange;
    public event Action<float, float> OnCharacterLifeChange;
    public event Action<int> onEnemySuccess;
    public event Action<int> OnWeaponChange;
    public event Action<int> onRewardEarned;
    public event Action OnWaveCleared;
    public event Action<int> OnGoldChange;
    public event Action OnPauseRequested;

    public event Action OnBuildingPhaseStarted;
    public event Action OnBuildingPhaseEnded;
    
    private bool _buildingPhase = false; // Add new variable

    public bool IsBuildingPhase // Add new property
    {
        get => _buildingPhase;
    }


    public event Action OnResumeRequested;

    #endregion


    #region ACTIONS

    public void ActionResumeRequested()
    {
        OnResumeRequested?.Invoke();
    }

    public void ActionPauseRequested()
    {
        OnPauseRequested?.Invoke();
    }

    public void ActionWaveCleared()
    {
        OnWaveCleared?.Invoke();
        _buildingPhase = true;
    }

    public void ActionGameOver(bool isVictory) 
    {     
        OnGameOver?.Invoke(isVictory);
    }

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

    public void ActionBuildingPhaseStarted() 
    {
        OnBuildingPhaseStarted?.Invoke();
    }

    public void ActionBuildingPhaseEnded() 
    {
        OnBuildingPhaseEnded?.Invoke();
        _buildingPhase = false;
    }
    #endregion
}