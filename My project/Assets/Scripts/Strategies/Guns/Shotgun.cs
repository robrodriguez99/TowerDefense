using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float _bulletsPerShell = 5;
    GameObject _bulletHole;


    protected override void Start()
    {
        base.Start();
        //For bullets placement
        _bulletHole = GameObject.Find("Shotgun_Bullet_Hole"); ;
    }

    protected override void Shoot()
    {
        currentShotCooldown = ShotCooldown;
        for (int i = 0; i < _bulletsPerShell; i++)
        {
            Instantiate(
                BulletPrefab,
                _bulletHole.transform.position + Random.insideUnitSphere * .5f,
                transform.rotation);
            EventManager.instance.ActionAmmoChange(CurrentBulletCount, MagSize);
        }
    }

}
