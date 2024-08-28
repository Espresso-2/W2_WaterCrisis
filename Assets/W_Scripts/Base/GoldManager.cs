using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace W_Scripts.Base
{
    public class GoldManager : MonoBehaviour
    {
        [NonSerialized] public int LeveIndex;
        [NonSerialized] public int CurrentLevelCoin = 0;
        [SerializeField] private GameObject[] son;
        public static GoldManager Instance;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            Debug.Log("计次");
            LeveIndex = SceneManager.GetActiveScene().buildIndex;
            HideGold();
        }

        public void AddCoin()
        {
            if (CurrentLevelCoin >= 3) return;
            CurrentLevelCoin += 1;
           UnityEngine.PlayerPrefs.SetInt("LeveCoin" + LeveIndex, CurrentLevelCoin);
           UnityEngine.PlayerPrefs.Save();
        }

        private void HideGold()
        {
            switch (UnityEngine.PlayerPrefs.GetInt("LevelCoin"+LeveIndex))
            {
                case 3:
                {
                    foreach (GameObject gold in son)
                    {
                        gold.gameObject.SetActive(false);
                    }
                    break;
                }
                case 2:
                {
                    for (int i = 0; i < 2; i++)
                    {
                        son[i].gameObject.SetActive(false);
                    }
                    break;
                }
                case 1:
                    son[0].gameObject.SetActive(false);
                    break;
                case 0:
                    Debug.Log("一个金币都没获取");
                    break;
            }
        }
    }
}