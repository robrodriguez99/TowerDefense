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
    [SerializeField] private int _currentBulletCount = 10;

    public float ShotCooldown => _shotCooldown;
    [SerializeField] private float _shotCooldown = .5f;
    private float _currentShotCooldown = 0;

    public virtual void Attack()
    {
        Debug.Log(_currentShotCooldown);
        if (ShotCooldownIsOver() && HasBullets())
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            _currentShotCooldown = _shotCooldown;
            _currentBulletCount--;

        }
    }

    public virtual void Reload() => _currentBulletCount = _magSize;

    private void Update()
    {

        if (_currentShotCooldown > 0) _currentShotCooldown -= Time.deltaTime;
        
    }

    protected bool HasBullets() => _currentBulletCount > 0;

    protected bool ShotCooldownIsOver() => _currentShotCooldown <= 0;

}
