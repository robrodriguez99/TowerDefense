using UnityEngine;
using System.Collections;

public class Turret : Gun, IRotable {

	protected Transform target;

    protected Animator animator;


    [Header("Attributes")]

	public float range = 15f;
	public float fireRate = 1f;

	[Header("Unity Setup Fields")]

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public Transform firePoint;

	public float RotationSpeed => _rotationSpeed;
	[SerializeField] private float _rotationSpeed = 10f;

    // Use this for initialization
    protected override void Start () {
        base.Start();
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
        animator = GetComponentInChildren<Animator>();

    }

    void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		} else
		{
			target = null;
		}

	}

	// Update is called once per frame
	void Update () {
		currentShotCooldown -= Time.deltaTime;
		if (target == null)
			return;
		partToRotate.LookAt(target);
		Attack();
	}

	protected override void Shoot ()
	{
		GameObject bulletGO = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        TurretBullet bullet = bulletGO.GetComponent<TurretBullet>();

        currentShotCooldown = ShotCooldown;
		animator.SetTrigger("ShootTurret");

		if (bullet != null)
		{
			bullet.WeaponDamage = Damage;
			bullet.Seek(target);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

    public void Rotation(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
