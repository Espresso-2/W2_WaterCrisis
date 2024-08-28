using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class FailedPanel : PanelBase
{
    protected override void OnEnable()
    {
        if (GoldManager.Instance.CurrentLevelCoin>0)
        {
            for (int i = 0; i < GoldManager.Instance.CurrentLevelCoin; i++)
            {
                CoinSon[i].SetActive(true);
            }
        }
    }
}