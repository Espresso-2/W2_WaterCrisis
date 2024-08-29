using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using W_Scripts.AdManager;

namespace W_Scripts
{
    //体力系统
    public class StaminaSystem : MonoBehaviour
    {
        /// <summary>
        /// 视图
        /// </summary>
        private StaminaView View;
        /// <summary>
        /// 主持者
        /// </summary>
        private StaminaPresenter Presenter;
        /// <summary>
        /// 体力恢复时间
        /// </summary>
        [SerializeField] private float RecoverTime = 600f;
        /// <summary>
        /// 是否唯一
        /// </summary>
        private static bool OnlyOne = true;
        /// <summary>
        /// 体力单例
        /// </summary>
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

        /// <summary>
        /// 添加体力
        /// </summary>
        public void AddStamina()
        {
            Presenter.AddStamina();
        }

        /// <summary>
        /// 删除体力
        /// </summary>
        public void RemoveStamina()
        {
            Presenter.RemoveStamina();
        }

        /// <summary>
        /// 解锁体力
        /// </summary>
        public void UnLockStamina()
        {
            DouyinAdManager.ShowReward(() => { Presenter.UnLockStamina(); });
        }

        /// <summary>
        /// 恢复体力携程
        /// </summary>
        /// <returns></returns>
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

        public bool CheckCurrentStamina()
        {
            return Presenter.GetCurrentStamina() > 0;
        }

        public void AddMaxStamina()
        {
            DouyinAdManager.ShowReward(() => { Presenter.AddMaxStamina(); });
        }
    }
}