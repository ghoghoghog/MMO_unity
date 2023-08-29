using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.Cameramode _mode = Define.Cameramode.Quaterview;
    [SerializeField] private Vector3 _delta = new Vector3(0,3,-4);
    [SerializeField] private GameObject _player;

    private void LateUpdate()
    {
        if (_mode == Define.Cameramode.Quaterview)
        {
           transform.position = _player.transform.position + _delta;
           transform.LookAt(_player.transform); 
        }
        
    }

    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.Cameramode.Quaterview;
        _delta = delta;
    }


}
