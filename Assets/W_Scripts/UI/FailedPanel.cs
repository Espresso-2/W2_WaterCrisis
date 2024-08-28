using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class FailedPanel : PanelBase
{
    private GoldManager goldManager;
    private void Awake()
    {
        goldManager = FindObjectOfType<GoldManager>();
    }
    protected override void OnEnable()
    {
        if (goldManager.CurrentLevelCoin>0)
        {
            for (int i = 0; i < goldManager.CurrentLevelCoin; i++)
            {
                CoinSon[i].SetActive(true);
            }
        }
    }
}