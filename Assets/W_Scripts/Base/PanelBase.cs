using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelBase : MonoBehaviour
{
   protected void ChangeActive()
   {
      gameObject.SetActive(!gameObject.activeSelf);
   }
}
