using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 100.0f;
    
    private Vector3 _desPos;
    private bool _moveToDest = false;
    private float wait_run_ration = 0;
    void Start()
    {
        Manager.Input.MouseAction += OnMousedClicked;
    }

    private void OnMousedClicked(Define.MouseEvent obj)
    {
        

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
        
        if (_moveToDest)
        {
            wait_run_ration = Mathf.Lerp(wait_run_ration, 1, 10 * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
                anim.SetFloat("wait_run_ratio",wait_run_ration);
            anim.Play("WAIT_RUN");
        }
        else
        {
            wait_run_ration = Mathf.Lerp(wait_run_ration, 0, 10 * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio",wait_run_ration);
            anim.Play("WAIT_RUN");
        }
        
        
        
        
    }

    private void OnMouseClicked(Define.MouseEvent obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Wall")))
        {
            _desPos = hit.point;
            _moveToDest = true;
        }
    }
    
}
