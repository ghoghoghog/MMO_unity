using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum State
    {
        Die,
        Moving,
        Idle,
        Skill
    }

    public enum Layer
    {
        Monster = 6,
        Ground = 7,
        Block = 8
    }

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
        Click,
        PointerDown,
        PointerUp
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

    public enum Worldobject
    {
        Unknown,
        Player,
        Monster

    }
}

