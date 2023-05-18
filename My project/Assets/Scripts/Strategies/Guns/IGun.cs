using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun 
{
    //Properties

    GameObject BulletPrefab { get; }

    int Damage { get; }

    int MagSize { get; }    

    int CurrentBulletCount { get; }

    float ShotCooldown { get; }

    // Actions

    void Attack();

    void Reload();
    
}
