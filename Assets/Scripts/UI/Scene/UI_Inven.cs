using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Manager.Resource.Destroy(child.gameObject);

        for (int i = 0; i < 20; i++)
        {
            GameObject item = Manager.UI.MakeSubItem<UI_Inven_Item>(parent: gridPanel.transform).gameObject;
            //item.transform.SetParent(gridPanel.transform);
            
            UI_Inven_Item invenItem = Util.GetOrAddComponent<UI_Inven_Item>(item);
            invenItem.SetInfo($"집행검{i}번");
        }
    }

    private void Start()
    {
        Init();
    }
}
