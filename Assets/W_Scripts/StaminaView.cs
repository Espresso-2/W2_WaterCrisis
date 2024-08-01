using UnityEngine;
using UnityEngine.Serialization;
using W_Scripts.UI;

namespace W_Scripts
{
    public class StaminaView : MonoBehaviour, IStaminaView
    {
        [SerializeField] private Slot [] slots;

        public void UpdateUI(StaminaDataModel model)
        {
            for (int i = 0; i < model.MaxStaminaCount; i++)
            {
                slots[i].CurrentState = SlotState.UnLock;
            }
            for (int i = 0; i < model.LockStaminaCount; i++)
            {
                slots[model.MaxStaminaCount-model.LockStaminaCount + i].CurrentState = SlotState.Lock;
            }
            for (int i = 0; i < model.CurrentStamina; i++)
            {
                slots[i].CurrentState = SlotState.Has;
            }
        }
    }
}