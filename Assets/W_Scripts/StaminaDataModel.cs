using UnityEngine;

namespace W_Scripts
{
    public class StaminaDataModel
    {
        private int currentStamina;
        private int maxStaminaCount;
        private int lockStaminaCount;
        public int CurrentStamina => currentStamina;
        public int MaxStaminaCount => maxStaminaCount;
        public int LockStaminaCount => lockStaminaCount;
        private const string lockStamina = "LockStamina";

        public void Init()
        {
            maxStaminaCount = 10;
            lockStaminaCount = PlayerPrefs.GetInt(lockStamina, 5);
            currentStamina = maxStaminaCount - lockStaminaCount;
        }

        public void UnLockStamina()
        {
            if (CheckLockCount())
            {
                Debug.Log("没有可以解锁的");
                return;
            }
            lockStaminaCount--;
            currentStamina++;
            PlayerPrefs.SetInt(lockStamina, lockStaminaCount);
        }

        public void AddCurrentStamina()
        {
            if (currentStamina == maxStaminaCount)
            {
                Debug.Log("体力值己满");
                return;
            }
            currentStamina++;
        }

        public void RemoveCurrentStamina()
        {
            if (CheckCurrentStaminaCountIsLow())
            {
                Debug.Log("体力值为0不能减少");
            }
            currentStamina--;
        }

        public bool CheckLockCount()
        {
            return lockStaminaCount == 0;
        }

        public bool CheckCurrentStaminaCountIsLow()
        {
            return currentStamina <= 0;
        }
    }
}