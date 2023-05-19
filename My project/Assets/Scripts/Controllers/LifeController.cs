using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{


    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife = 100;
    [SerializeField] private bool isMainCharacter = false;
    public void RecoverLife(int amount) => _currentLife += amount;

    public void TakeDamage(int damage) {
        _currentLife -= damage;
        if (isMainCharacter)
           ActionUpdateUiLife();
        if (!IsAlive()) Die();
     }

    // Start is called before the first frame update
    void Start()
    {
        _currentLife = MaxLife;
    }

    public bool IsAlive() => _currentLife > 0;

    public void Die() {
        if (!isMainCharacter) {
            EventManager.instance.ActionRewardEarned(10);
            Destroy(this.gameObject);
        }

        if (isMainCharacter) {
            EventManager.instance.ActionGameOver(false);
        }
        
    }

    private void ActionUpdateUiLife() {
        EventManager.instance.ActionCharacterLifeChange(_currentLife, MaxLife);
    }
}
