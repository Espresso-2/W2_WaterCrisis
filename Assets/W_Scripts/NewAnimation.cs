using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NewAnimation : MonoBehaviour
{
    public Vector3 Max=new Vector3(1.2f, 1.2f, 0);
    public Vector3 Mini=new Vector3(0.5f,0.5f,0.5f);
    private Tweener _tweener;
    private void OnEnable()
    {
        _tweener=  transform.DOScale(Max, 2f)
            .SetEase(Ease.InOutQuad) // 设置缓动效果，平滑的放大和缩小
            .SetLoops(-1, LoopType.Yoyo); // 无
    }

    private void OnDisable()
    {
        _tweener.Kill();
    }
}