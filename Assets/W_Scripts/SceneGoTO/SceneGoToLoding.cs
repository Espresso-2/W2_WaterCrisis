using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGoToLoding : MonoBehaviour
{
   private void Awake()
   {
#if UNITY_EDITOR
       Debug.Log("锁帧");
       Application.targetFrameRate = 60;
#endif
      SceneManager.LoadScene("Loading");
   }
}
