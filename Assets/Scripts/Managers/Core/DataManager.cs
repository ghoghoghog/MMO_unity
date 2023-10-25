using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public interface ILoader<key, Value>
{
    Dictionary<key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();


    public void Init()
    {
        StatDict = LoadJson<Data.StatData, int, Stat>("StatData").MakeDict();
    }
    Loader LoadJson<Loader , Key , Value>(string path)
    {
        TextAsset textAsset = Manager.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }

}


