using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using W_Scripts;
using W_Scripts.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text Level;
    public int LoadLevel => PlayerPrefs.GetInt("Level", 1);

    private Dictionary<int, Level> CurrentLevelShows = new();

    private int CurrentIndex = -1;

    [SerializeField] private GameObject StartGameButton;
    [SerializeField] private Transform LevelShowRoot;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private StaminaSystem StaminaSystem;
    public static MenuManager Instance;

    // Start is called before the first frame update
    protected void Awake()
    {
        Instance = this;
        Level.text = "关卡" + LoadLevel;
    }

    void Start()
    {
        //如果当前关卡解锁则显示下一个关卡但不可用
        for (int i = 1; i <= LoadLevel + 1; i++)
        {
            InstantiateLevelShow(i);
        }
        foreach (Level level in CurrentLevelShows.Values)
        {
            level.OnSelected += LevelSelected;
        }
    }

    private void Update()
    {
        StartGameButton.SetActive(value: CurrentIndex != -1);
    }

    public void StartGame()
    {
        StaminaSystem.LoadNextScene();
        SceneManager.LoadScene(CurrentIndex);
    }

    private void InstantiateLevelShow(int LevelIndex)
    {
        GameObject NewLevelShow = GameObject.Instantiate(Prefab, LevelShowRoot);
        var level = NewLevelShow.GetComponent<Level>();
        level.levelIndex = LevelIndex;
        CurrentLevelShows.Add(LevelIndex, level);
    }

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
}