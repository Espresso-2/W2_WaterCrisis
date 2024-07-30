using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace W_Scripts.UI
{
    public class Level : MonoBehaviour
    {
        private bool IsLock;
        private int Coins;
        public int levelIndex { get; set; }
        private GameObject UnLock;
        private GameObject Lock;
        private GameObject Selected;
        private GameObject Animal;
        public bool IsSelected { get; set; }
        public Action<int> OnSelected;
        [NonSerialized] public Text LevelText;

        private void Awake()
        {
            UnLock = transform.Find("UnLock").gameObject;
            Lock = transform.Find("Lock").gameObject;
            Selected = transform.Find("Selected").gameObject;
            Animal = transform.Find("animal").gameObject;
            

            #region 产生一个随机数让随机选择一个动物形象

            var range = Random.Range(0, 2);
            Animal.transform.GetChild(range).gameObject.SetActive(true);

            #endregion
        }

        private void Start()
        {
            LevelText = transform.GetChild(4).GetComponent<Text>();
            LevelText.text = "第" + levelIndex + "关";
            Debug.Log(levelIndex);
        }

        public void OnUnLockClick()
        {
            IsSelected = true;
            OnSelected?.Invoke(levelIndex);
        }

        private void Update()
        {
            #region 更新视图窗口该显示当前选关的状态
            //当前关卡索引大于通过关卡的索引证明是还未通过则返回false,其他都为True
            IsLock = MenuManager.Instance.LoadLevel < levelIndex;
            Lock.SetActive(IsLock);
            UnLock.SetActive(value: (!IsLock && !IsSelected));
            Selected.SetActive(value: (IsSelected && !IsLock));

            #endregion
        }
    }
}