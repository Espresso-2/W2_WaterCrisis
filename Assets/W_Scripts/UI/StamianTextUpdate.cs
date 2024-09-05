using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using W_Scripts;

public class StamianTextUpdate : MonoBehaviour
{
    private Text Text;
    private void Awake()
    {
        Text = GetComponent<Text>();
        Text.text = "10:00";
    }

    private void Update()
    {
        if (StaminaSystem.Instance!=null)
        {
            if (StaminaSystem.Instance.ShowRecover != string.Empty)
            {
                Text.text = StaminaSystem.Instance.ShowRecover;
            }
        }
    }
}
