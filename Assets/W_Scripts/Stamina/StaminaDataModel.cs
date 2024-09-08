using UnityEngine;

namespace W_Scripts
{
    public static class StaminaDataModel
    {
        /// <summary>
        /// 当前的体力数
        /// </summary>
        public static int currentStamina;
        /// <summary>
        /// 未解锁的体力槽数
        /// </summary>
        public static int lockStaminaSlot;
        /// <summary>
        /// 最大体力数量
        /// </summary>
        public static int maxStamina = 10;
        /// <summary>
        /// 存档String
        /// </summary>
        private const string LockStamina = "LockStamina";

        static StaminaDataModel()
        {
            //初始化默认锁定的数量为5
            lockStaminaSlot = PlayerPrefs.GetInt(LockStamina, 5);
            //通过将最大体力减掉未解锁的体力数量得到当前体力值
            currentStamina = maxStamina - lockStaminaSlot;
        }

        /// <summary>
        /// 添加体力方法 如果当前体力小于最大体力数减去未解锁体力则当前体力加1
        /// </summary>
        public static void AddStamina()
        {
            if (currentStamina < maxStamina - lockStaminaSlot)
            {
                currentStamina++;
            }
        }

        /// <summary>
        /// 加满体力方法，最大体力值减去当前的体力值减去未解锁的体力值得到的值加到当前体力上
        /// </summary>
        public static void AddMaxStamina()
        {
            currentStamina += (maxStamina - lockStaminaSlot - currentStamina);
        }

        /// <summary>
        /// 移除体力值，当前体力大于0才可减1
        /// </summary>
        public static void RemoveStamina()
        {
            if (currentStamina > 0)
            {
                currentStamina--;
            }
        }

        /// <summary>
        /// 解锁体力，未解锁的体力减1，当前体力加一，存贮未解锁体力的值
        /// </summary>
        public static void UnLockStamina()
        {
            if (lockStaminaSlot == 0)
            {
                return;
            }
            lockStaminaSlot--;
            PlayerPrefs.SetInt(LockStamina, lockStaminaSlot);
            PlayerPrefs.Save();
        }
    }
}