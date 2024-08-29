namespace W_Scripts
{
    public class StaminaPresenter
    {
        private IStaminaView staminaView;

        public StaminaPresenter(IStaminaView view)
        {
            staminaView = view;
            UpdateUI();
        }

        public void AddStamina()
        {
            StaminaDataModel.AddStamina();
            UpdateUI();
        }

        public void RemoveStamina()
        {
            StaminaDataModel.RemoveStamina();
            UpdateUI();
        }

        public int GetCurrentStamina()
        {
            return StaminaDataModel.currentStamina;
        }

        public void UnLockStamina()
        {
            StaminaDataModel.UnLockStamina();
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (staminaView != null)
            {
                staminaView?.UpdateUI();
            }
        }
    }
}