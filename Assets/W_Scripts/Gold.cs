using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;

public class Gold : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("谁接触到了金币----------"+other.name);
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            PlayerPrefs.SetInt("LevelCoin" + GoldManager.LeveIndex, PlayerPrefs.GetInt("LeveCoin" + GoldManager.LeveIndex) + 1);
            Destroy(gameObject);
        }
    }
}