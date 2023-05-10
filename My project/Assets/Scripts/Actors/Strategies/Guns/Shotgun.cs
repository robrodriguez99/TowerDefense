using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float _bulletsPerShell = 5;
    public override void Attack()
    {
        for (int i = 0; i < _bulletsPerShell; i++)
        {
            Instantiate(
                BulletPrefab,
                transform.position + Random.insideUnitSphere * 1,
                transform.rotation);
        }
    }
}
