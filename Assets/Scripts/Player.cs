using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Manager mg = Manager.GetInstance();
        Debug.Log(mg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
