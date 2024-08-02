using UnityEngine;
using UnityEngine.Serialization;
using W_Scripts.UI;

namespace W_Scripts
{
    public class StaminaView : MonoBehaviour, IStaminaView
    {
        [SerializeField] private Slot[] slots;

        public void UpdateUI()
        {
            for (int i = 0; i < StaminaDataModel.maxStamina; i++)
            {
                slots[i].CurrentState = SlotState.UnLock;
            }
            for (int i = 0; i < StaminaDataModel.currentStamina; i++)
            {
                slots[i].CurrentState = SlotState.Has;
            }
            for (int i = slots.Length-1; i > StaminaDataModel.lockStamina; i--)
            {
                slots[i].CurrentState = SlotState.Lock;
            }
           
        }
    }
}