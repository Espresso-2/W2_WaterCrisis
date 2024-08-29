using UnityEngine;
using UnityEngine.UI;
using W_Scripts;
using W_Scripts.Base;

public class WinPanel : PanelBase
{
    [SerializeField] private GameObject GetMAxCoinButton;
    private GoldManager goldManager;
    [SerializeField] private Button NextLevel;
    private void Awake()
    {
        goldManager = FindObjectOfType<GoldManager>();
    }

    protected override void OnEnable()
    {
        GetMAxCoinButton.SetActive(goldManager.CurrentLevelCoin < 3);
        if (goldManager.CurrentLevelCoin > 0)
        {
            for (int i = 0; i < goldManager.CurrentLevelCoin; i++)
            {
                CoinSon[i].SetActive(true);
            }
        }
        NextLevel.interactable = StaminaSystem.Instance.CheckCurrentStamina();
    }

    protected override void OnDisable()
    {
        GetMAxCoinButton.SetActive(true);
    }
}