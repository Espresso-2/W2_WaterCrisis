using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;
using W_Scripts;
using W_Scripts.AdManager;

public class GameManagerUI : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private SettingPanel settingPanel;
    [SerializeField] private Button SettingBtn;
    [SerializeField] private Button Ready;
    [SerializeField] private Button ReStart;
    [SerializeField] private Text LevelText;
    private SpawnWater spawnWater;
    private RectTransform ReadyRect;
    private RectTransform ReStartRect;

    private void Start()
    {
        LevelText.text = "第 " + SceneManager.GetActiveScene().buildIndex + " 关";
        ReStartRect = ReStart.gameObject.GetComponent<RectTransform>();
        ReadyRect = Ready.gameObject.GetComponent<RectTransform>();
        spawnWater = GetComponent<SpawnWater>();
        SettingBtn.onClick.AddListener(() => { settingPanel.gameObject.SetActive(true); });
        Ready.onClick.AddListener(() =>
        {
            spawnWater.SpawnReady();
            var OriginalX = ReadyRect.anchoredPosition.x;
            ReadyRect.DOAnchorPosX(175, 1f);
            ReStartRect.DOAnchorPosX(OriginalX, 1f);
        });
    }

    void Update()
    {
        slider.value = (SpawnWater.instance.waterDrop / 80) * 100;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RewardRestart()
    {
        DouyinAdManager.ShowReward(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        StaminaDataModel.RemoveStamina();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}