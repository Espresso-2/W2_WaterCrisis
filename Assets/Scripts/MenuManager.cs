using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text Level;
    int LevelNum;

    // Start is called before the first frame update
    void Start()
    {
        LevelNum = PlayerPrefs.GetInt("Level", 1);
        Level.text = "关卡" + LevelNum;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LevelNum);
    }
}