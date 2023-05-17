using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet 
{   
   float Lifetime { get; }

   void Travel();

   void OnCollisionEnter(Collision collision);
   
}
