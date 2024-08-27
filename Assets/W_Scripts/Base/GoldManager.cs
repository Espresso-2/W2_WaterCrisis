using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace W_Scripts.Base
{
    public class GoldManager : MonoBehaviour
    {
        public int LeveIndex;
        [SerializeField] private GameObject[] son;
        public static GoldManager Instance;
       
        private int LastLeveCoinValue = 0;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
            }
            LeveIndex = SceneManager.GetActiveScene().buildIndex;
          
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey("LevelCoin"+LeveIndex)|| PlayerPrefs.GetInt("LevelCoin"+LeveIndex) == 0) return;
            for (int i = 0; i < PlayerPrefs.GetInt("LevelCoin"+LeveIndex); i++)
            {
                son[i].SetActive(false);
            }
        }
    }
}