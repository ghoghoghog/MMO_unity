using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Level : UI_Scene
{
    enum Texts
    {
        Level
    }
    PlayerStat playerstat;

    public override void Init()
    {
        base.Init();
        Bind<TextMeshProUGUI>(typeof(Texts));
    }
    
    void Start()
    {
        Init();
        playerstat = Manager.Game.GetPlayer().GetComponent<PlayerStat>();
    }

    private void Update()
    {
        GetTextMeshProUGUI((int)Texts.Level).text = "Level" + playerstat.Level;
    }
}
