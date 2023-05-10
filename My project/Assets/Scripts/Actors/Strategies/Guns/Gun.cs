using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public GameObject BulletPrefab => _bulletPrefab;
    [SerializeField] private GameObject _bulletPrefab;

    public int Damage => _damage;
    [SerializeField] private int _damage = 10;

    public int MagSize => _magSize;
    [SerializeField] private int _magSize = 20;

    public int CurrentBulletCount => _currentBulletCount;
    [SerializeField] private int _currentBulletCount = 0;

    public float ShotCooldown => _shotCooldown;
    [SerializeField] private float _shotCooldown = .5f;
    private float _currentCooldown = 0;

    public virtual void Attack()
    {
        Instantiate(BulletPrefab, transform.position, transform.rotation);
    }

    public virtual void Reload() => _currentBulletCount = _magSize;

    private void Update()
    {
        _currentCooldown -= Time.deltaTime;
        if (_currentCooldown <= 0)
            _currentCooldown = _shotCooldown;

    }

}
