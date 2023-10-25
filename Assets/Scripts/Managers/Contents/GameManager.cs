using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager 
{
    private GameObject _player;
    private HashSet<GameObject> _monsters = new HashSet<GameObject>();

    public Action<int> OnSpawnEvent;

    public GameObject GetPlayer()
    {
        return _player;
    }
    public GameObject Spawn(Define.Worldobject type, string path, Transform parent = null)
    {
        GameObject go = Manager.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Define.Worldobject.Monster:
                _monsters.Add(go);
                if (OnSpawnEvent != null)
                {
                    OnSpawnEvent.Invoke(1);
                }
                break;
            case Define.Worldobject.Player:
                _player = go;
                break;
        }
        return go;
    }

    public Define.Worldobject GetWorldobjectType(GameObject go)
    {
        BaseController bc = go.GetComponent<BaseController>();
        if (bc == null)
            return Define.Worldobject.Unknown;

        return bc.WorldobjectType;
    }

    public void Despawn(GameObject go)
    {
        Define.Worldobject type = GetWorldobjectType(go);

        switch (type)
        {
            case Define.Worldobject.Monster:
               {
                   if (_monsters.Contains(go))
                   {
                     _monsters.Remove(go);
                     if (OnSpawnEvent != null)
                     {
                         OnSpawnEvent.Invoke(-1);
                     }
                   }
               } 
                break;
            case Define.Worldobject.Player:
                if (_player==go)
                {
                    _player = null;
                }
                break;
        }
        Manager.Resource.Destroy(go);
    }
}
