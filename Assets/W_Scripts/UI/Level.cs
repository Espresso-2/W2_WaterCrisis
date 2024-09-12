using System;
using Spine.Unity;
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
        private GameObject neW;
        [SerializeField] private GameObject[] Golds;
        public bool IsSelected { get; set; }
        public Action<int> OnSelected;
        [NonSerialized] public Text LevelText;
        public SkeletonGraphic CurrentAnimation { get; private set; }

        public SkeletonGraphic Track;

        private void Awake()
        {
            neW = transform.Find("NeW").gameObject;
            UnLock = transform.Find("UnLock").gameObject;
            Lock = transform.Find("Lock").gameObject;
            Selected = transform.Find("Selected").gameObject;
            Animal = transform.Find("animal").gameObject;

            #region 产生一个随机数让随机选择一个动物形象

            var range = Random.Range(0, 3);
            Animal.transform.GetChild(range).gameObject.SetActive(true);
            CurrentAnimation = Animal.transform.GetChild(range).GetComponent<SkeletonGraphic>();

            #endregion
        }

        private void Start()
        {
            //由于生成一个游戏对象时游戏物体的生命周期开始运转 Awake OnEnable 几乎同时执行尽管描述Awake要比OnEnable执行的快但实际可能会慢也可能会快，
            //当在生成时获取脚本传入字段的值必须要等组件初始化完毕也就是在Awake与OnEnable后
            //才正确赋值所以不要将金币的获取放在Awake中执行，因为还没有数值

            #region 获取关卡所得的金币数

            Coins = PlayerPrefs.GetInt("LevelCoinNumber" + levelIndex, 0);
            ShowGold(Coins);

            #endregion

            neW.gameObject.SetActive(PlayerPrefs.GetInt("Level", 1) == levelIndex);
            LevelText = transform.GetChild(4).GetComponent<Text>();
            LevelText.text = "第  " + levelIndex + "  关";
        }

        public void OnUnLockClick()
        {
            IsSelected = true;
            CurrentAnimation.timeScale = 1;
            CurrentAnimation.AnimationState.SetAnimation(0, CurrentAnimation.startingAnimation, true);
            Track.timeScale = 1;
            Track.AnimationState.SetAnimation(0, "lun", true);
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
            
            if (IsLock)
            {
                Debug.Log("000000000000000000000000000");
                LevelText.color = new Color(85f / 255f, 84f / 255f, 84f / 255f, 1f);
            }
            else if (!IsLock && !IsSelected)
            {
                Debug.Log("111111111111111111111111");
                LevelText.color = new Color(126f / 255f, 76f / 255f, 51f / 255f, 1f);
            }
            else if (IsSelected && !IsLock)
            {
                Debug.Log("222222222222222222222222222");
                LevelText.color = new Color(138f / 255f, 63f / 255f, 31f / 255f, 1f);
            }
            #endregion

            if (!IsSelected && CurrentAnimation != null && Track != null)
            {
                CurrentAnimation.timeScale = 0;
                Track.timeScale = 0;
            }
        }

        private void ShowGold(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Golds[i].SetActive(true);
            }
        }
    }
}