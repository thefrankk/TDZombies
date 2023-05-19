using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _moneyText;

   private void Awake()
   {
      MoneyManager.OnMoneyUpdated += UpdateMoneyText;   
   }

   private void Start()
   {
       UpdateMoneyText(0);
   }

   private void UpdateMoneyText(int money)
   {
        _moneyText.text = $"Cash: {money.ToString()}";
   }
}
