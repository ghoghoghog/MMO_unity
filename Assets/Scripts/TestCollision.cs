using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
            
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
    }
}
