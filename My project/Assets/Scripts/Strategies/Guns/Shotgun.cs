using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float _bulletsPerShell = 5;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Shoot()
    {
        currentShotCooldown = ShotCooldown;
        for (int i = 0; i < _bulletsPerShell; i++)
        {
            Instantiate(
                BulletPrefab,
                transform.position + Random.insideUnitSphere * 1,
                transform.rotation);
        }
    }

}
