using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using W_Scripts.AdManager;

public class RestartNumber : MonoBehaviour
{
    private GameManagerUI gameManagerUI;
    [SerializeField]private GameObject Ad;
    private static int Number = 10;
    [SerializeField] private Text numberText;
    private void Awake()
    {
        gameManagerUI = FindObjectOfType<GameManagerUI>();
       
    }

    private void Start()
    {
        UpdateText(Number);
        if (Number<= 0)
        {
            numberText.text = "增加5次";
            Ad.SetActive(true);
            GetComponent<Button>().onClick.AddListener(() =>
            {
                Number += 5;
                UpdateText(Number);
                gameManagerUI.RewardRestart();
            });
        }
        else if (Number >0)
        {
            Ad.SetActive(false);
            GetComponent<Button>().onClick.AddListener(() =>
            {
                Number--;
                UpdateText(Number);
                gameManagerUI.Restart();
            });
        }
        Debug.Log("Number"+Number);
    }

    private void UpdateText(int Number)
    {
        numberText.text = $"剩余次数：{Number}";
    }
}