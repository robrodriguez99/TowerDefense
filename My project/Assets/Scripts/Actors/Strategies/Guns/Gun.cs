using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public GameObject BulletPrefab => _bulletPrefab;
    [SerializeField] private GameObject _bulletPrefab;


    public AudioClip shootingSound;  // Add this line
    protected AudioSource audioSource;  // And this one


    public int Damage => _damage;
    [SerializeField] private int _damage = 10;

    public int MagSize => _magSize;
    [SerializeField] private int _magSize = 20;

    public int CurrentBulletCount => _currentBulletCount;
    [SerializeField] private int _currentBulletCount = 10;

    public float ShotCooldown => shotCooldown;
    [SerializeField] protected float shotCooldown = 1f;
    protected float currentShotCooldown = 0;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)  // Add an AudioSource if there isn't one already
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    public virtual void Attack()
    {
        Debug.Log(currentShotCooldown);
        if (CanShoot())
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            currentShotCooldown = shotCooldown;
            _currentBulletCount--;
            audioSource.PlayOneShot(shootingSound);  // Add this line


        }
    }

    public virtual void Reload() => _currentBulletCount = _magSize;

    private void Update()
    {

        if (currentShotCooldown > 0) currentShotCooldown -= Time.deltaTime;
        
    }

    protected bool HasBullets() => _currentBulletCount > 0;

    protected bool ShotCooldownIsOver() => currentShotCooldown <= 0;

    protected bool CanShoot() => HasBullets() && ShotCooldownIsOver();

}
