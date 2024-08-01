using System;

namespace W_Scripts
{
    public class StaminaSystem : SingletonBase<StaminaSystem>
    {
        private StaminaDataModel Model;
        private StaminaView View;
        private StaminaPresenter Presenter;
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            Model = new();
            Presenter = new(Model);
            View = FindObjectOfType<StaminaView>();
            Presenter.AttachView(View);
        }

        public void LoadNextScene()
        {
            if (Presenter!=null)
            {
                Presenter.LoadNextScene();
            }
        }
    }
}