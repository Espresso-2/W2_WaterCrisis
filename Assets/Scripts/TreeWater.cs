using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using W_Scripts.Base;

public class TreeWater : MonoBehaviour
{
    public int WaterDrops;
    public GameObject Win;
    float pos=0.0175f;
    Vector2 newPos;
    public static bool IsWin;
    private int LevelIndex;

    private void Awake()
    {
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        newPos = new Vector2(transform.position.x, transform.position.y);
        IsWin = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);
        WaterDrops++;
        newPos = new Vector2(transform.position.x, transform.position.y + pos);
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), newPos,
            1 * Time.deltaTime);
        SpawnWater.instance.WaterScore();
        if (WaterDrops >= 80 && !IsWin)
        {
            IsWin = true;
            IsNeedAddLeveIndex();
            Win.SetActive(IsWin);
        }
    }

    private void IsNeedAddLeveIndex()
    {
        if (PlayerPrefs.GetInt("Level",1) <= LevelIndex)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("正在游玩之间的关卡");
        }
    }
}