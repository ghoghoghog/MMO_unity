using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Manager : MonoBehaviour
{
  static Manager s_Instance; //유일성

  public static Manager GetInstance()
  {
    Init();
    return s_Instance;
  }

  private void Start()
  {
    Init();
  }

  private static void Init()
  {
    if (s_Instance ==null)
    {
      GameObject go = GameObject.Find("@Managers");
      if (go==null)
      {
        go = new GameObject() { name = "@Managers" };
        go.AddComponent<Manager>();

      }

      s_Instance = go.GetComponent<Manager>();
    }
  }
  
}
