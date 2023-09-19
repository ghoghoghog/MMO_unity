using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    protected virtual void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;
        Manager.UI.ShowSceneUI<UI_Inven>();
    }

    public override void Clear()
    {
        throw new System.NotImplementedException();
    }
}
