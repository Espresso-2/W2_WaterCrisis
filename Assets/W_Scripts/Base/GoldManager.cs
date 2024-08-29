using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace W_Scripts.Base
{
    public class GoldManager : MonoBehaviour
    {
        internal int CurrentLevelCoin = 0;
        [SerializeField]
        private GameObject[] Golds;
        internal int LevelBuildIndex;

        private void Awake()
        {
            LevelBuildIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void Start()
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
            Debug.Log("进入");
            switch (CurrentLevelCoin)
            {
                case 0:
                    for (int i = 0; i < Golds.Length; i++)
                    {
                        Golds[i].SetActive(true);
                    }
                    break;
                case 1:
                    for (int i = 0; i < Golds.Length-1; i++)
                    {
                        Golds[i].SetActive(true);
                    }
                    break;
                case 2:
                    Golds[0].SetActive(true);
                    break;
                case 3:
                    for (int i = 0; i < Golds.Length; i++)
                    {
                        Golds[i].SetActive(false);
                    }
                    break;
                default:
                    Debug.LogError("错误的数字");
                    break;
            }
        }
    }
}