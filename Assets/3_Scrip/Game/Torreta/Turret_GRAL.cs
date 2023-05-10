using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Turret_GRAL : MonoBehaviour
{
    public float buyPrice;
    public float sellPrice;


    public LayerMask layerDetection;
    public float range;
    public Zombie currentTarget;
    public List<Zombie> currentTargets = new List<Zombie>();

    private void EnemyDetection()
    {
        var enemy = Physics.OverlapSphere(transform.position, range).where(currentEnemy.Getcomponent<Zombie>())

    }


}


