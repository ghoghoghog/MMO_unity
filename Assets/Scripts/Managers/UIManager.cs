using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class UIManager
{
    private int _order = 10;
    private Stack<UI_PopUp> _popupStack = new Stack<UI_PopUp>();
    private UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root"};
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }
    
    public T ShowSceneUI<T>(string prefabName = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(prefabName))
            prefabName = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Scene/{prefabName}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;
        
        return sceneUI;
    }
    
    public T ShowPopupUI<T>(string prefabName = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(prefabName))
            prefabName = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Popup/{prefabName}");
        T popup = Util.GetOrAddComponent<T>(go);
        
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);
        
        return popup;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;
        
        UI_PopUp popup = _popupStack.Pop();
        Manager.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }
    
    public void ClosePopupUI(UI_PopUp pop)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != pop)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }
        ClosePopupUI();
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
}
