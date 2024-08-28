using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;
using DG.Tweening;

public class Gold : MonoBehaviour
{
    private Collider2D selfCollider2d;
    private SpriteRenderer spriteRenderer;
    private bool IsNotFirst = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        selfCollider2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Metaball_liquid") && IsNotFirst)
        {
            IsNotFirst = false;
            GoldManager.Instance.AddCoin();
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOJump(transform.position, 2f, 2, 1f));
            sequence.Join(transform.DORotate(new Vector3(0, 180, 0), 1f, RotateMode.FastBeyond360));
            sequence.Append(spriteRenderer.DOFade(0, 1f).OnComplete(() =>
            {
                sequence.Kill();
                HideSelf();
            }));
        }
    }

    public void HideSelf()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowSelf()
    {
        gameObject.SetActive(true);
    }
}