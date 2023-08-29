using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 100.0f;

    public float _yAngle = 0f;
    private Vector3 _desPos;
    private bool _moveToDest = false;
    void Start()
    {
        Manager.Input.KeyAction -= OnKeyboard;
        Manager.Input.KeyAction += OnKeyboard;  //구독 신청
        Manager.Input.MouseAction -= OnMousedClicked;
        Manager.Input.MouseAction += OnMousedClicked;
    }

    private void OnMousedClicked(Define.MouseEvent obj)
    {
        if (obj != Define.MouseEvent.Click)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray .direction* 100, Color.red, 1);

        LayerMask mask= LayerMask.GetMask("Wall");


        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,100,mask))
        { 
            _desPos = hit.point;
            _moveToDest = true;
            
        }
    }

    private void Update()
    {
        if (_moveToDest)
        {
            Vector3 dir = _desPos - transform.position;
            if (dir.magnitude < 0.0001f)
            {
                _moveToDest = false;
            }
            else
            {
                float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDist;
                if (dir.magnitude >0.01f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(dir), 30 * Time.deltaTime);
                }
            }
        }
    }

    private void OnMouseClicked(Define.MouseEvent obj)
    {
        if (obj != Define.MouseEvent.Click)
            return;
        
        Debug.Log("OnMouseClicked !");
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Wall")))
        {
            _desPos = hit.point;
            _moveToDest = true;
        }
    }

    private void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        _moveToDest = false;
    }
}
