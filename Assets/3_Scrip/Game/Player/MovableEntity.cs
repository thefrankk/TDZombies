using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableEntity : LifeEntities
{
   protected float _speedMovement;

   public float SpeedMovement => _speedMovement;
  
   protected abstract void MoveEntity();
   
   
   public virtual void SetSpeedMovement(float speed)
   {
       _speedMovement = speed;
   }
}
