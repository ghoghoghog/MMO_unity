using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : BaseScene
{
    public TextMeshProUGUI text;
    private PlayerStat playerstat;

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
        //Manager.UI.ShowSceneUI<UI_Inven>();

        //Data.Stat levelStat = Manager.Data.StatDict[1];

        gameObject.GetOrAddComponent<CursorController>();

        GameObject player = Manager.Game.Spawn(Define.Worldobject.Player, "unitychan");
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        GameObject go = new GameObject { name = "SpawningPool" };
        SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        pool.SetKeepMonsterCount(5);
        
        Manager.UI.ShowSceneUI<UI_Level>();
        Manager.Sound.Play("Sounds/RaindropFlower", Define.Sound.Bgm);
        
    }

    protected void Update()
    {
        
    }

    public override void Clear()
    {
        
    }
}

