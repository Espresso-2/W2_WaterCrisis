using System;
using UnityEngine;
using UnityEngine.UI;
using W_Scripts;
using W_Scripts.AdManager;
using W_Scripts.Base;

public class WinPanel : PanelBase
{
    //[SerializeField] private GameObject GetMAxCoinButton;
    private GoldManager goldManager;
    [SerializeField] private Button NextLevel;
    [SerializeField] private Button AddMaxCoin;
    private Text Tips;

    private void Awake()
    {
        goldManager = FindObjectOfType<GoldManager>();
        Tips = NextLevel.transform.Find("Text").GetComponent<Text>();
    }

    private void Start()
    {
        AddMaxCoin.onClick.AddListener(() =>
        {
            DouyinAdManager.ShowReward(() =>
            {
                goldManager.AddMaxCoin();
                for (int i = 0; i < goldManager.CurrentLevelCoin; i++)
                {
                    CoinSon[i].SetActive(true);
                }
            });
        });
    }

    protected override void OnEnable()
    {
        AddMaxCoin.gameObject.SetActive(goldManager.CurrentLevelCoin < 3);
        if (goldManager.CurrentLevelCoin > 0)
        {
            for (int i = 0; i < goldManager.CurrentLevelCoin; i++)
            {
                CoinSon[i].SetActive(true);
            }
        }
        NextLevel.interactable = StaminaSystem.Instance.CheckCurrentStamina();
        Tips.text = StaminaSystem.Instance.CheckCurrentStamina() ? "下一关" : "体力不足";
    }

    protected override void OnDisable()
    {
        AddMaxCoin.gameObject.SetActive(true);
    }
}