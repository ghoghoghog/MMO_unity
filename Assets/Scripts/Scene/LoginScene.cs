using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    private BaseScene _baseSceneImplementation;

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;
    }

    public override void Clear()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Manager.Scene.LoadScene(Define.Scene.Game);
        }
    }
    
}
