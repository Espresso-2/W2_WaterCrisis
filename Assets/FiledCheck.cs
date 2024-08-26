using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiledCheck : MonoBehaviour
{
    public float FiledTime;
    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.transform.tag);
        if (other.transform.CompareTag("Metaball_liquid"))
        {
            FiledTime -= Time.deltaTime;
            if (FiledTime <= 0)
            {
                SpawnWater.instance.Filed.SetActive(true);
            }
        }
    }
}
