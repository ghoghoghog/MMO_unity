using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Manager : MonoBehaviour
{
  static Manager Instance; //유일성

  public static Manager GetInstance()
  {
    Init();
    return Instance;
  }

  private void Start()
  {
    Init();
  }

  private static void Init()
  {
    if (Instance ==null)
    {
      GameObject go = GameObject.Find("@Managers");
      if (go==null)
      {
        go = new GameObject() { name = "@Managers" };
        go.AddComponent<Manager>();

      }

      Instance = go.GetComponent<Manager>();
    }
  }
  
}
