using System;
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

        public void LoadNextScene()
        {
            Presenter.LoadNextScene();
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