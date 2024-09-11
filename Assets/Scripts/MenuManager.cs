using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using W_Scripts;
using W_Scripts.AdManager;
using W_Scripts.UI;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// 主界面展示的关卡文本
    /// </summary>
    [SerializeField] private Text Level;
    /// <summary>
    /// 可以游玩的关卡
    /// </summary>
    public int LoadLevel;
    /// <summary>
    /// 当前展示的关卡实例字典，以关卡索引为key
    /// </summary>
    private Dictionary<int, Level> CurrentLevelShows = new();
    /// <summary>
    /// 当前选中的关卡索引
    /// </summary>
    private int CurrentIndex = -1;
    /// <summary>
    /// 开始按钮游戏对象
    /// </summary>
    [SerializeField] private GameObject StartGameButton;
    /// <summary>
    /// 生成预制体的根节点
    /// </summary>
    [SerializeField] private Transform LevelShowRoot;
    /// <summary>
    /// 关卡预制体
    /// </summary>
    [SerializeField] private GameObject Prefab;
    /// <summary>
    /// 体力系统实例
    /// </summary>
    [SerializeField] private StaminaSystem StaminaSystem;
    /// <summary>
    /// 体力不足提示
    /// </summary>
    [SerializeField] private CanvasGroup StaminaLess;
    
    public static MenuManager Instance;

    /// <summary>
    /// 记录单例，从存档中获取可以进行那一关
    /// </summary>
    protected void Awake()
    {
        Instance = this;
        LoadLevel = PlayerPrefs.GetInt("Level", 1);
        Level.text = "关卡" + LoadLevel;
    }

    /// <summary>
    /// 初始化关卡UI个数，并为选中操作添加事件
    /// </summary>
    void Start()
    {
        //如果当前关卡解锁则显示下一个关卡但不可用
        for (int i = 1; i <= LoadLevel + 1; i++)
        {
            if ((LoadLevel + 1) >= 50)
            {
                break;
            }
            InstantiateLevelShow(i);
        }
        foreach (Level level in CurrentLevelShows.Values)
        {
            level.OnSelected += LevelSelected;
        }
    }

    /// <summary>
    /// 必须选中关卡才会展示开始游戏按钮
    /// </summary>
    private void Update()
    {
        StartGameButton.SetActive(value: CurrentIndex != -1);
    }

    /// <summary>
    /// 开始游戏按钮点击事件，移除体力值并将加载指定的关卡索引值
    /// </summary>
    public void StartGame()
    {
        if (StaminaSystem.CheckCurrentStamina())
        {
            StaminaSystem.RemoveStamina();
            SceneManager.LoadScene(CurrentIndex);
        }
        else
        {
           FadeStamina();
        }
        
    }

    /// <summary>
    /// 生成关卡UI预制体并传入关卡索引值
    /// </summary>
    /// <param name="LevelIndex"></param>
    private void InstantiateLevelShow(int LevelIndex)
    {
        GameObject NewLevelShow = GameObject.Instantiate(Prefab, LevelShowRoot);
        var level = NewLevelShow.GetComponent<Level>();
        level.levelIndex = LevelIndex;
        CurrentLevelShows.Add(LevelIndex, level);
    }

    /// <summary>
    /// 选中关卡回调事件，当选中当前索引关卡时将其他关卡的选中状态取消并记录当前选中关卡的索引为下一次场景跳转做暂存
    /// </summary>
    /// <param name="levelIndex"></param>
    private void LevelSelected(int levelIndex)
    {
        foreach (int Key in CurrentLevelShows.Keys)
        {
            if (Key == levelIndex)
            {
                continue;
            }
            CurrentLevelShows[Key].IsSelected = false;
        }
        CurrentIndex = levelIndex;
    }

    /// <summary>
    /// 注销事件
    /// </summary>
    private void OnDestroy()
    {
        foreach (Level level in CurrentLevelShows.Values)
        {
            level.OnSelected -= LevelSelected;
        }
    }

    private void FadeStamina()
    {
        StaminaLess.DOFade(1, 1f).OnComplete(() =>
        {
            StaminaLess.DOFade(0, 1f);
        });
    }

    public void OnClickAdd()
    {
      
    }
}