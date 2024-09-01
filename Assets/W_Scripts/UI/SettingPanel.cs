using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : PanelBase
{
    [SerializeField]
    private Toggle MusicToggle;
    [SerializeField]
    private Toggle SoundToggle;
    public static bool MusicIsOn=true;
    private SoundManager soundManager;
    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        MusicToggle.isOn = MusicIsOn;
        MusicToggle.onValueChanged.AddListener(_ =>
        {
            MusicIsOn = MusicToggle.isOn;
            soundManager.OnOFFMusic(MusicIsOn);
        });
    }
}