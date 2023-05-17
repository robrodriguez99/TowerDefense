using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{
    public int MaxLife => _maxLife;
    [SerializeField] private int _maxLife = 100;

    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife = 0;

    public void RecoverLife(int amount) => _currentLife += amount;

    public void TakeDamage(int damage) {
        _currentLife -= damage;
        if (!IsAlive()) Die();
     }

    // Start is called before the first frame update
    void Start()
    {
        _currentLife = _maxLife;
    }

    public bool IsAlive() => _currentLife > 0;

    public void Die() => Destroy(this.gameObject);
}
