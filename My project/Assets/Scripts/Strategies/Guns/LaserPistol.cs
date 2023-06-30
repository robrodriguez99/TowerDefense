using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserPistol : Gun
{
    Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();

    }


    public override void Attack()
    {
        if (CanShoot())
        {
            Shoot();
            audioSource.PlayOneShot(shootingSound);
            animator.SetTrigger("Shoot");
        }

    }

    public override void Reload()
    {
        base.Reload();
    }

    
}
