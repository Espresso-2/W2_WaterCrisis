using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class WinPanel : PanelBase
{
    [SerializeField] private GameObject GetMAxCoinButton;
    protected override void OnEnable()
    {
        UnityEngine.PlayerPrefs.SetInt("Level"+GoldManager.Instance.LeveIndex,GoldManager.Instance.LeveIndex+1);
        GetMAxCoinButton.SetActive(GoldManager.Instance.CurrentLevelCoin<3);
        if (GoldManager.Instance.CurrentLevelCoin>0)
        {
            for (int i = 0; i < GoldManager.Instance.CurrentLevelCoin; i++)
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