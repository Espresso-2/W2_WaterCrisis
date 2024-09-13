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
    [SerializeField] private GameObject AdICon;
    [SerializeField] private GameObject RewardText;
    private Text Tips;
    private GameManagerUI gameManagerUI;

    private void Awake()
    {
        goldManager = FindObjectOfType<GoldManager>();
        Tips = NextLevel.transform.Find("Text").GetComponent<Text>();
        gameManagerUI = FindObjectOfType<GameManagerUI>();
    }

    protected override void OnEnable()
    {
        RewardText.SetActive(false);
        AdICon.SetActive(false);
        AddMaxCoin.gameObject.SetActive(goldManager.CurrentLevelCoin < 3);
        if (goldManager.CurrentLevelCoin > 0)
        {
            for (int i = 0; i < goldManager.CurrentLevelCoin; i++)
            {
                CoinSon[i].SetActive(true);
            }
        }
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
        if (StaminaSystem.Instance.CheckCurrentStamina())
        {
            NextLevel.onClick.AddListener(gameManagerUI.NextLevel);
        }
        else
        {
            RewardText.SetActive(true);
            AdICon.SetActive(true);
            NextLevel.onClick.RemoveListener(gameManagerUI.NextLevel);
            NextLevel.onClick.AddListener(() =>
            {
                DouyinAdManager.ShowReward(() => { gameManagerUI.RewardNextLevel(); });
            });
        }
    }

    protected override void OnDisable()
    {
        AddMaxCoin.gameObject.SetActive(true);
    }
}