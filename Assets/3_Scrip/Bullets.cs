using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
   protected float _speed;
   protected float _damage;

   public virtual void HitTarget<T>(T target) where T : Component
   {
      Destroy(this.gameObject);
   }
}
