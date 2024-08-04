using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace W_Scripts.Base
{
    public class GoldManager : MonoBehaviour
    {
        public static int LeveIndex;
        [SerializeField]
        private GameObject[] son;
        private void Awake()
        {
            LeveIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void Start()
        {
            var Count = PlayerPrefs.GetInt("LevelCoin" + LeveIndex, 0);
            for (int i = 0; i < Count; i++)
            {
                son[i].SetActive(false);
            }
        }
    }
}