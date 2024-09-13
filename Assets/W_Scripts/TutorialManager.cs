using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private GameObject TutorialPanel1;
    private GameObject TutorialPanel2;

    private void Start()
    {
        TutorialPanel1 = transform.GetChild(0).gameObject;
        TutorialPanel2 = transform.GetChild(1).gameObject;
        Button T1 = TutorialPanel1.GetComponent<Button>();
        Button T2 = TutorialPanel2.GetComponent<Button>();
        if (PlayerPrefs.HasKey("Tutorial"))
        {
            TutorialPanel1.SetActive(false);
            TutorialPanel2.SetActive(false);
        }
        else if(!PlayerPrefs.HasKey("Tutorial"))
        {
            TutorialPanel1.SetActive(true);
            TutorialPanel2.SetActive(false);
            T1.onClick.AddListener(() =>
            {
                TutorialPanel1.SetActive(false);
                TutorialPanel2.SetActive(true);
            });
            T2.onClick.AddListener(() =>
            {
                TutorialPanel2.SetActive(false);
                PlayerPrefs.SetInt("Tutorial", 1);
                PlayerPrefs.Save();
            });
        }
    }
    
}