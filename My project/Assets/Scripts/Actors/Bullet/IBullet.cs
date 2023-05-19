using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet 
{   
    GameObject ImpactEffect { get; }

   float Lifetime { get; }

   void Travel();

   void OnTriggerEnter(Collider collision);
   
}
