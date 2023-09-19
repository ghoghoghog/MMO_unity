using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UI_PopUp : UI_Base
{
 
   public virtual void ClosePopUpUI()
   {
      Manager.UI.ClosePopupUI(this);
   }

   public override void Init()
   {
      Manager.UI.SetCanvas(gameObject, true);
   }
}
