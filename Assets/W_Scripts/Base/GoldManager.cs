using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace W_Scripts.Base
{
    public class GoldManager : MonoBehaviour
    {
        [NonSerialized] public int LeveIndex;
        [NonSerialized] public int CurrentLevelCoin = 0;
         private Gold[] son;

         private void Awake()
         {
             son = GetComponentsInChildren<Gold>();
         }

         private void Start()
        {
            LeveIndex = SceneManager.GetActiveScene().buildIndex;
            CurrentLevelCoin = PlayerPrefs.GetInt("LevelCoin" + LeveIndex, 0);
            Debug.Log($"当前场景获取的金币数量：{CurrentLevelCoin}");
            HideGold();
        }

        public void AddCoin()
        {
            if (CurrentLevelCoin >= 3) return;
            CurrentLevelCoin += 1;
            PlayerPrefs.SetInt("LeveCoin" + LeveIndex, CurrentLevelCoin);
            PlayerPrefs.Save();
        }

        private void HideGold()
        {
            switch (CurrentLevelCoin)
            {
                case 0 :
                    foreach (Gold gold in son)
                    {
                        gold.gameObject.SetActive(true);
                    } ;
                    break;
                case 1:
                    for (int i = 0; i < 2; i++)
                    {
                        son[i].gameObject.SetActive(true);
                    }
                    ;
                    break;
                case 2:
                    son[0].gameObject.SetActive(true);
                    break;
                case 3:
                    foreach (Gold gold in son)
                    {
                        gold.gameObject.SetActive(false);
                    } ;
                    break;
                default:
                    Debug.LogError("错误的数字");
                    break;
            }
        }
    }
}