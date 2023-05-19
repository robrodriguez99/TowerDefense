using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "BulletStats", menuName = "Stats/Bullet/BasicBullet", order = 0)]
public class BulletStats : ScriptableObject
{
    [SerializeField] private BulletStatValues _statValues;

    public float Lifetime => _statValues.lifetime;

    public GameObject ImpactEffect => _statValues.impactEffect;

    public float MovementSpeed => _statValues.movementSpeed;

}

[System.Serializable]
public struct BulletStatValues
{
    public float lifetime;
    public GameObject impactEffect;
    public float movementSpeed;
}
