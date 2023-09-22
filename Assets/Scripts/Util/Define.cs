using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
      Unknown,
      Login,
      Lobby,
      Clear,
      Game
    }
    public enum CameraMode
    {
        QuaterView
    }
    
    public enum MouseEvent
    {
        Press, 
        Click
    }
    
    public enum UIEvent
    {
        Click,
        Drag
    }


    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }
    
}
