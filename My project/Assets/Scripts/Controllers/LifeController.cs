using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{


    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;
    public GameObject deathEffectPrefab;

    public GameObject coinPrefab;
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife = 100;
    [SerializeField] private bool _isMainCharacter = false;
    public void RecoverLife(int amount) => _currentLife += amount;

    public void TakeDamage(int damage) {
        _currentLife -= damage;
        if (_isMainCharacter)
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
        if (!_isMainCharacter) {
            if (deathEffectPrefab != null)
                Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            Instantiate(coinPrefab, transform.position, coinPrefab.transform.rotation);
            Destroy(this.gameObject);
        } else {
            EventManager.instance.ActionGameOver(false);
        }
        
    }

    private void ActionUpdateUiLife() {
        EventManager.instance.ActionCharacterLifeChange(_currentLife, MaxLife);
    }
}
