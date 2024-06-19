using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UITurretsManager : MonoBehaviour
{
   [SerializeField] private UITurretsMenu _popUp;
   
   public static UITurretsManager Instance { get; private set; }
   public int Id { get; }


   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
         Destroy(this);
      
   }



   public void OpenOrClosePopUp(Node node)
   {
      _popUp.OpenOrClosePopUp(node);
   }
   
  
}
