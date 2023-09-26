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
            yield return 4;        
        }
    }
    
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Manager.UI.ShowSceneUI<UI_Inven>();

        Stat levelStat = Manager.Data.StatDict[1];
        Debug.Log("LevelStat.Level : " + levelStat.level);
    }

    public override void Clear()
    {
        
    }
}
