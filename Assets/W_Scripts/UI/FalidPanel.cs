using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class FalidPanel : PanelBase
{
    protected override void OnEnable()
    {
        var CoinCount = PlayerPrefs.GetInt("LevelCoin" + GoldManager.LeveIndex);
        for (int i = 0; i < CoinCount; i++)
        {
            CoinSon[i].SetActive(true);
        }
    }
}