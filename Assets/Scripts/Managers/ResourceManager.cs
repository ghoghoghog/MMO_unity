using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    public T load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path)
    {
        GameObject ("Prefebs/(path)");
        if (prefeb==null)
        {
            Debug.Log($"Failed to load prefeb : {path}");
        }
    }
    
}
