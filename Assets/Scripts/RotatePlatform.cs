﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Water2D;

public class RotatePlatform : MonoBehaviour
{
    public float speedRotate;
    // Start is called before the first frame update
    public static RotatePlatform instance;

    void Start()
    {
        // Water2D_Spawner.instance.Restore();
        // WaterSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !SpawnWater.instance.WaterSpawned)
        {
            if (!IsPointerOverUIElement())
            {
                transform.Rotate(Vector3.forward * (speedRotate * Time.deltaTime));
            }
        }
    }

    private bool IsPointerOverUIElement()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}