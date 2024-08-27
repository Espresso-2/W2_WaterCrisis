using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class FalidPanel : PanelBase
{
    protected override void OnEnable()
    {
        var CoinCount = UnityEngine.PlayerPrefs.GetInt("LevelCoin"+GoldManager.Instance.LeveIndex,0);
        if(CoinCount==0)return;
        for (int i = 0; i < CoinCount; i++)
        {
            CoinSon[i].SetActive(true);
        }
    }
}