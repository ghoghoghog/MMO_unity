using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UI_PopUp : UI_Base
{
   public virtual void Init()
   {
      Manager.UI.SetCanvas(gameObject, true);
   }

   public virtual void ClosePopUpUI()
   {
      Manager.UI.ClosePopUpUI(this);
   }
}
