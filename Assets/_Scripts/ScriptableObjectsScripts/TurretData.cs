using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "ScriptableObjects/TurretData", order = 1)]
public class TurretData : ScriptableObject
{
  [SerializeField] private Turret_GRAL _turretPrefab;
  [SerializeField] private int _costAmount;
  [SerializeField] private int _upgradeCostAmount;
  [SerializeField] private int _upgradeCount;

  public int SellAmount => _costAmount - (_costAmount / 4);
  public Turret_GRAL TurretPrefab => _turretPrefab;
  public int CostAmount => _costAmount;

}
