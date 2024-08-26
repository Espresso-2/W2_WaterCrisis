using System;
using Spine;
using Spine.Unity;
using UnityEngine;
using Water2D;

public class SpawnWater : MonoBehaviour
{
    public static SpawnWater instance;
    public bool WaterSpawned;
    public float waterDrop = 0;
    public SkeletonAnimation GetWater;
    public GameObject Filed;
    private bool IsFild;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        WaterSpawned = false;
    }



    public void SpawnReady()
    {
        GetWater.AnimationState.SetAnimation(0, "move", false).Complete += Spawn;
    }

    private void Spawn(TrackEntry trackentry)
    {
        WaterSpawned = true;
        Water2D_Spawner.instance.SpawnAll();
    }

    public void WaterScore()
    {
        waterDrop++;
    }
}