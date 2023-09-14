using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class UIManager
{
    private int _order = 10;
    private Stack<UI_PopUp> _popupStack = new Stack<UI_PopUp>();

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root==null)
            {
                root = new GameObject { name = "@UI_Root" };
            }
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
            canvas.sortingOrder = (_order);
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowPopupUI<T>(string prefebname = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(prefebname))
        {
            prefebname = typeof(T).Name;
        }
        GameObject go = Manager.Resource.Instantiate($"UI/PopUp/{prefebname}");
        T popup = Util.GetOrAddComponent<T>(go);
        
        _popupStack.Push(popup);

        GameObject root = GameObject.Find("@UI_Root");
        if (root==null)
        {
            root = new GameObject { name = "@UI_Root" };
        }
        go.transform.SetParent(root.transform);
        return popup;
    }
    
    public void ClosePopUpUI()
    {
        if (_popupStack.Count ==0)
        {
            return;
        }

        UI_PopUp popup = _popupStack.Pop();
        Manager.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }

    public void ClosePopUpUI(UI_PopUp pop)
    {
        if (_popupStack.Count ==0)
        {
            return;
        }

        if (_popupStack.Peek()!=pop)
        {
            Debug.Log("Close popup Faled");
            return;
        }
        ClosePopUpUI();
    }

    public void CloseAllPopUp()
    {
        while (_popupStack.Count>0)
        {
            ClosePopUpUI();
        }
    }
}
