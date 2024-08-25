using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelBase : MonoBehaviour
{
   [SerializeField] protected GameObject[] CoinSon;
   protected virtual void ChangeActive()
   {
      gameObject.SetActive(!gameObject.activeSelf);
   }

   protected virtual void OnEnable()
   {
      
   }

   protected virtual void OnDisable()
   {
      
   }
}
