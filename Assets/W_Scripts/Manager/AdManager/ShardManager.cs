using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using W_Scripts.AdManager;

[RequireComponent(typeof(Button))]
public class ShardManager : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(DouyinAdManager.GetStarkShare);
    }
}