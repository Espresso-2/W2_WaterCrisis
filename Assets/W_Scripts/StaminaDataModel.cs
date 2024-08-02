using UnityEngine;

namespace W_Scripts
{
    public static class StaminaDataModel
    {
        public static int currentStamina;
        public static int lockStamina;
        public static int maxStamina = 10;
        private const string LockStamina = "LockStamina";

        static StaminaDataModel()
        {
            lockStamina = PlayerPrefs.GetInt(LockStamina, 5);
            currentStamina = maxStamina - lockStamina;
        }

        public static void AddStamina()
        {
            if (currentStamina < maxStamina - lockStamina)
            {
                currentStamina++;
            }
        }

        public static void RemoveStamina()
        {
            if (currentStamina > 0)
            {
                currentStamina--;
            }
        }

        public static void UnLockStamina()
        {
            lockStamina--;
            AddStamina();
            PlayerPrefs.SetInt(LockStamina, lockStamina);
        }
    }
}