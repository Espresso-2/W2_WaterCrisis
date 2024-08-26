using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using W_Scripts.Base;
using DG.Tweening;

public class Gold : MonoBehaviour
{
    private string Key;
    private bool IsFirst = true;
    private Collider2D selfCollider2d;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        selfCollider2d = GetComponent<Collider2D>();
        Key = "LevelCoin" + GoldManager.LeveIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("谁接触到了金币----------" + other.name);
        if (other.gameObject.CompareTag("Metaball_liquid") && IsFirst)
        {
            selfCollider2d.enabled = false;
            IsFirst = false;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOJump(transform.position, 2f, 2, 1f));
            sequence.Join(transform.DORotate(new Vector3(0, 180, 0), 1f, RotateMode.FastBeyond360));
            sequence.Append(spriteRenderer.DOFade(0, 1f).OnComplete(() => { sequence.Kill(); Destroy(gameObject); }));
        }
        PlayerPrefs.SetInt(Key, PlayerPrefs.GetInt(Key) + 1);
    }
}