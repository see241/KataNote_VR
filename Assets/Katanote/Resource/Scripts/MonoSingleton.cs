using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance = _instance ?? MonoBehaviour.FindObjectOfType<T>();
        }
    }

    protected virtual void OnDestroy()
    {
        _instance = null;
    }
}

