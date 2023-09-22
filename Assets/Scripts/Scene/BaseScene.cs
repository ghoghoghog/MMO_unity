using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    public Define.Scene SceneType { get; protected set; }= Define.Scene.Unknown;

    protected virtual void Init()
    {
        object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj ==null)
        {
            Manager.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        }
    }

    public abstract void Clear();

}
