﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Water2D;

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
            Win.SetActive(IsWin);
            var Level = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("Level", Level + 1);
            //TODO:埋点
        }
    }
}