
using UnityEngine;

public interface IDamageable {

    int MaxLife { get; }

    int CurrentLifeCount { get; }

    void TakeDamage(int damage);



}
