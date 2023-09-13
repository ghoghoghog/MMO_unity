using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class UIManager
{
    private int _order = 0;
    private Stack<UI_PopUp> _popupStack = new Stack<UI_PopUp>();

    public T ShowPopupUI<T>(string prefebname = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(prefebname))
        {
            prefebname = typeof(T).Name;
        }
        GameObject go = Manager.Resource.Instantiate($"UI/PopUp/{prefebname}");
        T popup = Util.GetOrAddComponent<T>(go);
        
        _popupStack.Push(popup);
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
