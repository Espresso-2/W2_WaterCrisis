using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class WinPanel : PanelBase
{
    [SerializeField] private GameObject GetMAxCoinButton;
    protected override void OnEnable()
    {
        var CoinCount = PlayerPrefs.GetInt("LevelCoin" + GoldManager.LeveIndex);
        if (CoinCount == 0)
        {
            foreach (var son in CoinSon)
            {
                son.SetActive(false);
            }
        }
        else if (CoinCount==3)
        {
            GetMAxCoinButton.SetActive(false);
        }
        else
        {
            for (int i = 0; i < CoinCount; i++)
            {
                CoinSon[i].SetActive(true);
            }
        }
    }

    protected override void OnDisable()
    {
        GetMAxCoinButton.SetActive(true);
    }
}