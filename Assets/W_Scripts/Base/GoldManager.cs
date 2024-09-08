using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace W_Scripts.Base
{
    public class GoldManager : MonoBehaviour
    {
        internal int CurrentLevelCoin = 0;
        [SerializeField] private GameObject[] Golds;
        internal int LevelBuildIndex;

        private void Awake()
        {
            LevelBuildIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void OnEnable()
        {
            CurrentLevelCoin = PlayerPrefs.GetInt("LevelCoinNumber" + LevelBuildIndex.ToString(), 0);
            HideGold();
        }

        public void AddCoin()
        {
            if (CurrentLevelCoin >= 3) return;
            CurrentLevelCoin += 1;
            PlayerPrefs.SetInt("LevelCoinNumber" + LevelBuildIndex, CurrentLevelCoin);
            PlayerPrefs.Save();
        }

        private void HideGold()
        {
            Debug.Log($"当前关卡的金币数 :{CurrentLevelCoin}");
            var X = Golds.Length - CurrentLevelCoin;
            Debug.Log($"计算要遍历的次数 :{X}");
            for (int i = 0; i < X; i++)
            {
                Golds[i].SetActive(true);
            }
        }
    }
}