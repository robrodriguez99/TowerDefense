using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    int MaxLife { get; }
    int CurrentLife { get; }

    void TakeDamage(int damage);
    void RecoverLife(int amount);

    bool IsAlive();

    void Die();
}
