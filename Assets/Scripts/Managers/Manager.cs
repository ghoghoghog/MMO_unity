using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
  private static Manager s_Instance;
  private SoundManager _sound = new SoundManager();
  private SceneManagerEX _scene = new SceneManagerEX();
  public static SceneManagerEX Scene
  {
    get { return Instance._scene; }
  }

  public static SoundManager Sound
  {
    get { return Instance._sound; }
  }
  
  public static Manager Instance
  {
    get 
    {
      Init(); 
      return s_Instance;
    }
  }

  private InputManagers _input = new InputManagers();
  public static InputManagers Input
  {
    get
    {
      return Instance._input;
    }
  }
  
  
  
  private ResourceManager _resource = new ResourceManager();
  public static ResourceManager Resource
  {
    get
    {
      return Instance._resource;
    }
  }
  
  

  private UIManager _ui = new UIManager();
  public static UIManager UI
  {
    get
    {
      return Instance._ui;
    }
  }
  
  
  void Start()
  {
    Init();
  }

  private void Update()
  {
    _input.OnUpdate();
  }

  static void Init()
  {
    if (s_Instance == null)
    {
      GameObject go = GameObject.Find("@Manager");
      if (go == null)
      {
        go = new GameObject { name = "@Manager" };
        go.AddComponent<Manager>();
      }
      DontDestroyOnLoad(go);
      s_Instance = go.GetComponent<Manager>();
    }
  }
  
}
