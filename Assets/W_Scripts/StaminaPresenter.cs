namespace W_Scripts
{
    public class StaminaPresenter
    {
        private IStaminaView staminaView;
        private readonly StaminaDataModel staminaModel;

        public StaminaPresenter(StaminaDataModel model)
        {
            staminaModel = model;
            staminaModel.Init();
        }

        public void AttachView(IStaminaView view)
        {
            staminaView = view;
            staminaView.UpdateUI(staminaModel);
        }

        public void DestroyView()
        {
            staminaView = null;
        }

        public void AddStamina()
        {
            staminaModel.AddCurrentStamina();
            UpdateUI();
        }

        public void RemoveStamina()
        {
            staminaModel.RemoveCurrentStamina();
            UpdateUI();
        }

        public void LoadNextScene()
        {
            DestroyView();
            RemoveStamina();
        }

        public void UnLockStamina()
        {
            staminaModel.UnLockStamina();
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            staminaView?.UpdateUI(staminaModel);
        }
    }
}