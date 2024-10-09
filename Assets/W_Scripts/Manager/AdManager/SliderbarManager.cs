using UnityEngine;
using UnityEngine.UI;
using W_Scripts;
using W_Scripts.AdManager;

/// <summary>
/// 侧边栏管理
/// </summary>
public class SliderbarManager : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    /// <summary>
    /// 文字显示
    /// </summary>
    [SerializeField]
    private Image OpenSliderImage;
    /// <summary>
    /// 替换文字
    /// </summary>
    [SerializeField] private Sprite GerReward;

    /// <summary>
    /// 组件引用
    /// </summary>
    private void Awake()
    {
        DouyinAdManager.OnShowWithDict();
    }

    private void Start()
    {
        gameObject.SetActive(DouyinAdManager.isFormSliderbar);
        _button.onClick.AddListener(() =>
        {
            DouyinAdManager.GetStarkSideBar(() =>
            {
                OpenSliderImage.sprite = GerReward;
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(() => { StaminaSystem.Instance.UnLockStamina(); });
            });
        });
    }
}