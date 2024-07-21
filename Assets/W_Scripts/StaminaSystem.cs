using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using W_Scripts;

public class StaminaSystem : SingletonBase<StaminaSystem>
{
    [SerializeField] private Slot[] Slots;

    private int Stamina;
    public int CurrentStamina { get; set; }

    [SerializeField] private float time = 600f;

    [SerializeField] private Text TimerUI;

    private float Timer;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Intit();
        Timer = time;
    }
    
    private void Intit()
    {
        Stamina = PlayerPrefs.GetInt("Stamina", 5);
        CurrentStamina = Stamina;
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].state = i < Stamina ? StaminaState.Has : StaminaState.Lock;
        }
    }

    private void AddStamina()
    {
        if (CurrentStamina >= Stamina)  return;
        CurrentStamina++;
        SlotUpdates(CurrentStamina);
    }
    
    public void ReduceStamina()
    {
        if (CurrentStamina == 0)
        {
            //TODO:是否要展示体力值不足？
            return;
        }
        Slots[CurrentStamina].state = StaminaState.None;
        CurrentStamina--;
        
    }

    private void SlotUpdates(int currentStamina)
    {
        for (int i = 0; i < currentStamina; i++)
        {
            Slots[i].state = StaminaState.Has;
        }
    }
    

    private void Update()
    {
        if (CurrentStamina < Stamina)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                AddStamina();
                Timer = time;
            }
            int minutes = Mathf.FloorToInt(Timer / 60f);
            int seconds = Mathf.FloorToInt(Timer % 60f);
            TimerUI.text = string.Format("{0,00}:{1:00}", minutes, seconds);
        }
        else
        {
            TimerUI.text = "";
        }
    }

    public void UnLockSlotAd()
    {
        //TODO:观看视频解锁
        Stamina++;
        //先让UI更新为None，如果，当前体力值不满的情况下，这么做很有用，在添加新的体力值时排序就会正确
        Slots[Stamina].state = StaminaState.None;
        PlayerPrefs.SetInt("Stamina", Stamina);
        AddStamina();
    }
}