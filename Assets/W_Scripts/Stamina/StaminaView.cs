using UnityEngine;
using UnityEngine.Serialization;
using W_Scripts.UI;

namespace W_Scripts
{
    public class StaminaView : MonoBehaviour, IStaminaView
    {
        [SerializeField] private Slot[] slots;

        /// <summary>
        /// 更新体力显示情况
        /// </summary>
        public void UpdateUI()
        {
            //遍历最大体力数，将所有的插槽都设置为解锁状态
            for (int i = 0; i < StaminaDataModel.maxStamina; i++)
            {
                slots[i].CurrentState = SlotState.UnLock;
            }
            for (int i = 0; i < StaminaDataModel.currentStamina; i++)
            {
                slots[i].CurrentState = SlotState.Has;
            }
            //从后向前遍历，根据未解锁的插槽数量调整视图
            for (int i = slots.Length - 1; i >= slots.Length - StaminaDataModel.lockStaminaSlot && i >= 0; i--)
            {
                //因为从0开始所以最大索引是9
                slots[i].CurrentState = SlotState.Lock;
            }
            /*if (StaminaDataModel.currentStamina == StaminaDataModel.maxStamina)
            {
                for (int i = 0; i < StaminaDataModel.maxStamina; i++)
                {
                    slots[i].CurrentState = SlotState.Has;
                }
                return;
            }*/
            //遍历当前体力数，将所有插槽从0号索引开始依次设置为拥有状态

            //如果当前体力为最大值则不更新未解锁插槽显示
            Debug.Log($"未解锁的插槽数:{StaminaDataModel.lockStaminaSlot}" + $"当前的体力数量:{StaminaDataModel.currentStamina}");
        }
    }
}