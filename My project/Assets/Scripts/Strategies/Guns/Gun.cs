using UnityEngine;

public class Gun : MonoBehaviour, IGun
{

    [SerializeField] protected GunStats _gunStats;

    public GameObject BulletPrefab => _gunStats.BulletPrefab;


    public AudioClip shootingSound;  
    protected AudioSource audioSource; 


    public int Damage => _gunStats.Damage;

    public int MagSize => _gunStats.MagSize;

    public int CurrentBulletCount => _currentBulletCount;
    [SerializeField] private int _currentBulletCount;

    public float ShotCooldown => _gunStats.ShotCooldown;

    protected float currentShotCooldown = 0;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)  // Add an AudioSource if there isn't one already
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        _currentBulletCount = MagSize;
    }


    public virtual void Attack()
    {
        if (CanShoot())
        {
            Shoot();
            audioSource.PlayOneShot(shootingSound);
        }
    }

    public virtual void Reload() 
    {
        _currentBulletCount = MagSize;
        EventManager.instance.ActionAmmoChange(_currentBulletCount, MagSize);
    }

    private void Update()
    {
        if (currentShotCooldown > 0) currentShotCooldown -= Time.deltaTime;
    }

    protected virtual void Shoot()
    {
        GameObject gunBulletHole = GameObject.Find("Gun_Bullet_Hole");
        Instantiate(BulletPrefab, gunBulletHole.transform.position, transform.rotation);
        currentShotCooldown = ShotCooldown;
        _currentBulletCount--;

        EventManager.instance.ActionAmmoChange(_currentBulletCount, MagSize);
    }

    protected bool HasBullets() => _currentBulletCount > 0;

    protected bool ShotCooldownIsOver() => currentShotCooldown <= 0;

    protected bool CanShoot() => HasBullets() && ShotCooldownIsOver();

}
