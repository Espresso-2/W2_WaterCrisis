using System;
using System.Collections;
using UnityEngine;

namespace W_Scripts
{
    public class StaminaSystem : MonoBehaviour
    {
        private StaminaView View;
        private StaminaPresenter Presenter;

        private void Start()
        {
            View = FindObjectOfType<StaminaView>();
            Presenter = new(View);
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
    }
}