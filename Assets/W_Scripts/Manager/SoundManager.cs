using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource auidoSource;

    private void Awake()
    {
        auidoSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        OnOFFMusic(SettingPanel.MusicIsOn);
    }

    public void OnOFFMusic(bool isOn)
    {
        auidoSource.volume = isOn ? 1 : 0;
    }
}