using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    private int i = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        i++;
        if (i % 2 == 0)
            Manager.Sound.Play("univ0001", Define.Sound.Bgm);
        else
            Manager.Sound.Play("univ0002", Define.Sound.Bgm);
    }
}
