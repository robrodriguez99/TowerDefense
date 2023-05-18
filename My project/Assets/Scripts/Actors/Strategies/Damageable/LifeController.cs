using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeController : MonoBehaviour, IDamageable
{

    public int MaxLife => GetComponent<Actor>().ActorStats.MaxLife;
    public int CurrentLife => _currentLife;
    [SerializeField] private int _currentLife = 100;

    public void RecoverLife(int amount) => _currentLife += amount;

    public void TakeDamage(int damage) {
        Debug.Log("Taking damage");
        _currentLife -= damage;
        EventManager.instance.ActionCharacterLifeChange(_currentLife, MaxLife);
        if (!IsAlive()) Die();
     }

    // Start is called before the first frame update
    void Start()
    {
        _currentLife = MaxLife;
    }

    public bool IsAlive() => _currentLife > 0;

    public void Die() => Destroy(this.gameObject);
}
