using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdApplyDamage : ICommand
{
    private IDamageable _damageable;
    private int _damage;

    public CmdApplyDamage(IDamageable damagable, int damage)
    {
        _damageable = damagable;
        _damage = damage;
    }

    public void Execute() => _damageable.TakeDamage(_damage);
}

