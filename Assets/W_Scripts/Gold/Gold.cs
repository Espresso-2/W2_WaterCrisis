using UnityEngine;
using W_Scripts.Base;
using DG.Tweening;

/// <summary>
/// 场景中的金币
/// </summary>
public class Gold : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isCollected;
    private GoldManager goldManager;

    /// <summary>
    /// 获取所需的实例
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        goldManager = GetComponentInParent<GoldManager>();
    }

    /// <summary>
    /// 当进入的游戏对象时水时，当前场景获取的金币数量加一，并且OnTriggerEnter2D只会执行一次，调用DoTween动画组
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;
        if (other.gameObject.CompareTag("Metaball_liquid"))
        {
            isCollected = true;
            goldManager.AddCoin();
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOJump(transform.position, 2f, 2, 1f));
            sequence.Join(transform.DORotate(new Vector3(0, 180, 0), 1f, RotateMode.FastBeyond360));
            sequence.Append(spriteRenderer.DOFade(0, 1f).OnComplete(() =>
            {
                sequence.Kill();
                gameObject.SetActive(false);
            }));
        }
    }
}