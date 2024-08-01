using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
{
    private static T instance;
    public static T Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    protected virtual void Awake()
    {
        if (instance is null)
        {
            instance = this as T;
        }
    }
}