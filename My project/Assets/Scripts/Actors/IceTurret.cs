using UnityEngine;

public class IceTurret : Turret
{
    protected override void Shoot()
    {
        GameObject bulletGO = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log(bulletGO.GetComponent<TurretIceBullet>());

        TurretIceBullet bullet = bulletGO.GetComponent<TurretIceBullet>();
        currentShotCooldown = ShotCooldown;

        if (bullet != null)
        {
            bullet.WeaponDamage = Damage;
            bullet.Seek(target);
        }
    }
}
