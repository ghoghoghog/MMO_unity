using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Define.CameraMode _mode = Define.CameraMode.QuaterView;
    [SerializeField] private Vector3 _delta = new Vector3(0,3,-4);
    [SerializeField] private GameObject _player;

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }

    private void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            if (_player.isValid()==false)
            {
                return;
            }
            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, _delta, out hit,_delta.magnitude, 
                    LayerMask.GetMask("Block")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist + Vector3.up *1f;
            }
            else
            {
              transform.position = _player.transform.position + _delta;
              transform.LookAt(_player.transform);  
            }  
        }
        
    }

    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _delta = delta;
    }


}
