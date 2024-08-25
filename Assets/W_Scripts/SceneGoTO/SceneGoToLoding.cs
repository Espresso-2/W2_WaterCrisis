using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGoToLoding : MonoBehaviour
{
   private void Awake()
   {
      SceneManager.LoadScene("Loading");
   }
}
