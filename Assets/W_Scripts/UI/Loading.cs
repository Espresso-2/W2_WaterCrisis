using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider ProgressBar;
    [SerializeField] private Text Number;
    private float Duration = 3f;

    private void Awake()
    {
        ProgressBar.maxValue = 100f;
        ProgressBar.value = 0f;
        Number.text = string.Empty;
    }

    private void Start()
    {
        StartCoroutine(StartLoad());
    }

    private IEnumerator StartLoad()
    {
        var currentProgress = 0f;
        while (currentProgress < Duration)
        {
            var value = Mathf.Lerp(0, 100f, currentProgress / Duration);
            Number.text = Convert.ToInt32(value).ToString() + '%';
            ProgressBar.value = value;
            currentProgress += Time.deltaTime;
            yield return null;
        }
        ProgressBar.value = 100f;
        Number.text = "100%";
        SceneManager.LoadScene("Menu");
    }
}