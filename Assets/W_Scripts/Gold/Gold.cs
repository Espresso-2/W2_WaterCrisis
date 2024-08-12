using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class Gold : MonoBehaviour
{
    private string Key;
    private bool IsFirst=true;
    private void Start()
    {
        Key = "LevelCoin" + GoldManager.LeveIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("谁接触到了金币----------"+other.name);
        if (other.gameObject.CompareTag("Metaball_liquid")&&IsFirst)
        {
            IsFirst = false;
            PlayerPrefs.SetInt(Key, PlayerPrefs.GetInt(Key)+1) ;
            Destroy(gameObject);
        }
    }
}