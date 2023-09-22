using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Manager.UI.ShowSceneUI<UI_Inven>();

        for (int i = 0; i < 3; i++)
        {
            Manager.Resource.Instantiate("unitychan");
            Manager.Resource.Instantiate("Tank");
        }
    }

    public override void Clear()
    {
        
    }
}
