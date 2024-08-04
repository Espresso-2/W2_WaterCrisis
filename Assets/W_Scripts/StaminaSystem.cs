using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace W_Scripts
{
    public class StaminaSystem : MonoBehaviour
    {
        private StaminaView View;
        private StaminaPresenter Presenter;
        /*[SerializeField] private Text text;*/
        [SerializeField] private float RecoverTime = 600f;

        private static bool OnlyOne = true;
        public static StaminaSystem Instance;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                if (OnlyOne)
                {
                    DontDestroyOnLoad(gameObject);
                    OnlyOne = false;
                }
            }
        }

        private void Start()
        {
            View = FindObjectOfType<StaminaView>();
            Presenter = new(View);
            StartCoroutine(Recover());
        }

        public void AddStamina()
        {
            Presenter.AddStamina();
        }

        public void RemoveStamina()
        {
            Presenter.RemoveStamina();
        }

        public void UnLockStamina()
        {
            Presenter.UnLockStamina();
        }

        private IEnumerator Recover()
        {
            while (true) // 使用无限循环
            {
                float remainingTime = RecoverTime;
                while (remainingTime > 0)
                {
                    /*int minutes = Mathf.FloorToInt(remainingTime / 60);
                    int seconds = Mathf.FloorToInt(remainingTime % 60);*/
                    /*text.text = $"{minutes:00}:{seconds:00}";*/
                    yield return new WaitForSeconds(1f);
                    remainingTime--;
                }
                AddStamina();
                // Optionally handle when the countdown reaches zero
                /*text.text = "00:00";*/
            }
        }
    }
}