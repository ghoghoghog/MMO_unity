using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefebTest : MonoBehaviour
{
   // public GameObject prefeb;
    void Update()
    {
        //GameObject prefeb = Resources.Load<GameObject>("Prefebs/Tank");
        //GameObject tank= Instantiate(prefeb);
        Manager.Resouce.Instantiate("tank");
        
        
        Destroy(tank , 3f);
    }
}
