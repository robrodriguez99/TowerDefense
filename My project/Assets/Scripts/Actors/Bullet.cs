using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LifetimeController))]
public class Bullet : MonoBehaviour, IBullet, IMovable
{
    public BulletStats BulletStats => _bulletStats;

    public int WeaponDamage { get; set; }

    public float Lifetime => _bulletStats.Lifetime;

    public float MovementSpeed => _bulletStats.MovementSpeed;

    public GameObject ImpactEffect => _bulletStats.ImpactEffect;

    [SerializeField] protected BulletStats _bulletStats;

    protected LifetimeController lifetimeController;

    protected virtual void Start()
    {
        lifetimeController = GetComponent<LifetimeController>();
        lifetimeController.SetLifetime(Lifetime);
    }

    void Update()
    {
        Travel();
        if (lifetimeController.isLifetimeOver()) Destroy(this.gameObject);
    }

    public void Travel() => Move(Vector3.forward);

    public void OnTriggerEnter(Collider collision)
    {
        HitTarget();
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        //Have to check if is alive to avoid multiple calls to Die() 
        if (damageable != null && damageable.IsAlive()) new CmdApplyDamage(damageable, WeaponDamage).Execute();
        Destroy(this.gameObject);
    }

    protected void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(this.gameObject);
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * MovementSpeed * Time.deltaTime);
    }
}
