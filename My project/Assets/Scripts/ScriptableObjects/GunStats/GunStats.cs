using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "Stats/Guns/BasicGun", order = 0)]
public class GunStats : ScriptableObject
{
    [SerializeField] private GunStatValues _gunStats;

    public GameObject BulletPrefab => _gunStats.bulletPrefab;
    public int Damage => _gunStats.Damage;

    public int MagSize => _gunStats.MagSize;

    public float ShotCooldown => _gunStats.ShotCooldown;
}

[System.Serializable]
public struct GunStatValues
{
    public GameObject bulletPrefab;
    public int Damage;
    public int MagSize;
    public float ShotCooldown;
}

