using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagers : MonoBehaviour
{
   public Action KeyAction = null;

   public void OnUpdate()
   {
      if (Input.anyKey==false)
      {
         return;
      }
      if (KeyAction !=null)
      {
         KeyAction.Invoke();
      }
   }
}
