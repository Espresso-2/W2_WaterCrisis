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
            Debug.Log("当前体力值"+StaminaDataModel.currentStamina +"最大体力值"+StaminaDataModel.maxStamina);
            //遍历最大体力数，将所有的插槽都设置为解锁状态
            for (int i = 0; i < StaminaDataModel.maxStamina; i++)
            {
                slots[i].CurrentState = SlotState.UnLock;
            }
            if (StaminaDataModel.currentStamina == StaminaDataModel.maxStamina)
            {
                for (int i = 0; i < StaminaDataModel.maxStamina; i++)
                {
                    slots[i].CurrentState = SlotState.Has;
                }
                return;
            }
            //遍历当前体力数，将所有插槽从0号索引开始依次设置为拥有状态
            for (int i = 0; i < StaminaDataModel.currentStamina; i++)
            {
                slots[i].CurrentState = SlotState.Has;
            }
            //如果当前体力为最大值则不更新未解锁插槽显示
           
            //让当前体力的下一个槽位作为开始遍历的数组的末尾设置为未解锁
            for (int i = StaminaDataModel.currentStamina ; i < slots.Length; i++)
            {
                Debug.Log($"<color=Green><size=15>插槽索引:{i}｝</size></color>");
                slots[i].CurrentState = SlotState.Lock;
            }
        }
    }
}