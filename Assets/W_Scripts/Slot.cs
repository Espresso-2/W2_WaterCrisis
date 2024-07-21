using System;
using UnityEngine;

namespace W_Scripts
{
    public class Slot : MonoBehaviour
    {
        public StaminaState state;
        private GameObject HasStamina;
        private GameObject Lock;

        private void Start()
        {
            HasStamina = transform.GetChild(0).gameObject;
            Lock = transform.GetChild(1).gameObject;
        }

        private void UpdateUI()
        {
            switch (state)
            {
                case StaminaState.None:
                    HasStamina.SetActive(false);
                    Lock.SetActive(false);
                    break;
                case StaminaState.Lock:
                    HasStamina.SetActive(false);
                    Lock.SetActive(true);
                    break;
                case StaminaState.Has:
                    HasStamina.SetActive(true);
                    Lock.SetActive(false);
                    break;
            }
        }

        private void Update()
        {
            UpdateUI();
        }
    }
}