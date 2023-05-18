using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AvailableTurrets", menuName = "ScriptableObjects/AvailableTurrets", order = 1)]
public class AvailableTurrets : ScriptableObject
{
    [SerializeField] private List<TurretData> _turrets;

    public List<TurretData> Turrets => _turrets;
}
