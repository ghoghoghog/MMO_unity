﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class UI_ButtonBase : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);  //{PointText, ScoreText}
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);
        
        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T)==typeof(GameObject))
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            }

            if (objects[i]==null)
            {
                Debug.Log($"Fail to bind({names[i]})");
            }
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }
}