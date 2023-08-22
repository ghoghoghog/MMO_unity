using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefebTest : MonoBehaviour
{
    GameObject prefab;

    private GameObject tank;
    void Start()
    {
        tank = Manager.Resource.Instantiate("Tank");
        
        Manager.Resource.Destroy(tank, 3.0f);
    }
}
