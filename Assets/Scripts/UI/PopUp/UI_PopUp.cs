using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UI_PopUp : UI_Base
{
   public virtual void Init()
   {
      Manager.UI.SetCanvas(gameObject, true);
   }
}
