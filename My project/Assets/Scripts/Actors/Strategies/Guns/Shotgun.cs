using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float _bulletsPerShell = 5;


    private void Start()
    {
        base.Start();
        shotCooldown = 2f;
    }

    public override void Attack()
    {

        if (CanShoot())
        {
            currentShotCooldown = shotCooldown;
            for (int i = 0; i < _bulletsPerShell; i++)
            {
                Instantiate(
                    BulletPrefab,
                    transform.position + Random.insideUnitSphere * 1,
                    transform.rotation);
            }
            audioSource.PlayOneShot(shootingSound);  // Add this line
        }

    }
}
