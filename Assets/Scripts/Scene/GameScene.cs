using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{

    class CoroutineTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;        }
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Manager.UI.ShowSceneUI<UI_Inven>();

        CoroutineTest test = new CoroutineTest();
        foreach (System.Object t in test)
        {
            int value = (int)t;
            Debug.Log(value);
        }

        for (int i = 0; i < 10; i++)
        {
            Manager.Resource.Instantiate("unitychan");
            Manager.Resource.Instantiate("Tank");
        }
    }

    public override void Clear()
    {
        
    }
}
