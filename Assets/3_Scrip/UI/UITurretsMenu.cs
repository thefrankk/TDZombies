using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class UITurretsMenu : MonoBehaviour
{
  [SerializeField] private UnityEngine.UI.Button _buyButton;
  [SerializeField] private UnityEngine.UI.Button _sellButton;
  [SerializeField] private UnityEngine.UI.Button _upgradeButton;

  [SerializeField] private AvailableTurrets _turretsForBuy;

  private Node _currentNode;
  private void OnEnable()
  {
    _buyButton.onClick.AddListener(BuyTurret);
    _sellButton.onClick.AddListener(SellTurret);
    _upgradeButton.onClick.AddListener(UpgradeTurret);
  }

  public void OpenOrClosePopUp(Node node)
  {
    _currentNode = node;
    this.transform.position = new Vector3(node.transform.position.x + 0.5f,
      node.transform.position.y + 5f,
      node.transform.position.z);


    this.transform.ScaleTo(this.transform.localScale.x >= 0.1f ? Vector3.zero : new Vector3(0.2f, 0.2f, 0.2f), 0.5f);

  }
  private void BuyTurret()
  {
    if (_currentNode.GetCurrentTurret() != null) return;
    
    
    MoneyManager.TryToBuyItem(_turretsForBuy.Turrets.First().CostAmount, () =>
    {
      Turret_GRAL turret = _turretsForBuy.Turrets.First().TurretPrefab;
      Turret_GRAL createdTurret = Instantiate(turret, _currentNode.transform.position, Quaternion.identity, _currentNode.transform);
      _currentNode.SetCurrentTurret(createdTurret);
      Debug.Log("Bought turret");
    });
  }
  
  private void SellTurret()
  {
    var turret = _currentNode.GetCurrentTurret();
    if (turret == null) return;
    
    Destroy(turret.gameObject);

    var turretData = _turretsForBuy.Turrets.Where((x) => x.GetType() == turret.GetType()).First();
    
    MoneyManager.AddMoney(turretData.SellAmount);

  }
  
  private void UpgradeTurret()
  {
    Debug.Log("Upgraded turret");
  }
  
}
