using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 100.0f;
    
    private Vector3 _desPos;
    //private bool _moveToDest = false;
    private float wait_run_ration = 0;
    void Start()
    {
        Manager.Input.MouseAction += OnMouseClicked;

        // Manager.Resource.Instantiate("UI/UI_Button");
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle
    }

    private PlayerState _state = PlayerState.Idle;
    private void Update()
    {
        switch (_state)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
        }
    }
    private void UpdateIdle()
    {
        wait_run_ration = Mathf.Lerp(wait_run_ration, 0, 10 * Time.deltaTime);
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed",0);
        
    }

    private void UpdateMoving()
    {
        Vector3 dir = _desPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
            return;
        }
        
        float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
        transform.position += dir.normalized * moveDist;
        if (dir.magnitude >0.01f)
        { 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 
                30 * Time.deltaTime);
        } 
        //에니메이션
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed",_speed);
        wait_run_ration = Mathf.Lerp(wait_run_ration, 1, 10 * Time.deltaTime);

    }

    private void UpdateDie()
    {
        Debug.Log("Player Die");
    }
    
    private void OnMouseClicked(Define.MouseEvent obj)
    {
        if (_state == PlayerState.Die)
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Wall")))
        {
            _desPos = hit.point;
            _state = PlayerState.Moving;
        }
    }

    void OnRunEvent(string foot)
    {
        Debug.Log("뚜벅" + foot);
    }
}
