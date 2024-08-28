﻿using System;
using UnityEngine;
using W_Scripts.Base;

public class TreeWater : MonoBehaviour
{
    public int WaterDrops;
    public GameObject Win;
    float pos;
    Vector2 newPos;
    public static bool IsWin;

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
        pos = pos + 0.1f;
        newPos = new Vector2(transform.position.x, transform.position.y + pos);
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), newPos,
            1 * Time.deltaTime);
        SpawnWater.instance.WaterScore();
        if (WaterDrops >= 80 && !IsWin)
        {
            IsWin = true;
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            PlayerPrefs.Save();
            Win.SetActive(IsWin);
        }
    }
}