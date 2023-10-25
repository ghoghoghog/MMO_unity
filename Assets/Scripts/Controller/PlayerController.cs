using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseController
{
    private Stat _stat;
    private int _mask = (1 <<(int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);
    private bool _stopSkill = false;
    void Start()
    {
        WorldobjectType = Define.Worldobject.Player;
        _stat = gameObject.GetComponent<PlayerStat>();
        Manager.Input.MouseAction += OnMouseEvent;

        Manager.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }
    
 

    protected override void UpdateMoving()
    {
        if (_lockTarget !=null)
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= 1.5)
            {
                State = Define.State.Skill;
                return;
            }
        }
        
        Vector3 dir = _destPos - transform.position;
        dir.y = 0;
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
            return;
        }
        
        Debug.DrawRay(transform.position + Vector3.up * 0.5f , dir.normalized , Color.green);
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f , dir , 1, LayerMask.GetMask("Block")))
        {
            if(Input.GetMouseButton(0)==false)
                State = Define.State.Idle;
            return;
        }
        
        float moveDist = Math.Clamp(_stat.Movespeed * Time.deltaTime, 0, dir.magnitude);
        transform.position += dir.normalized * moveDist;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 50 * Time.deltaTime);
    }
    
    protected override void UpdateSkill()
    {
        if (_lockTarget!=null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }
    
    
    void OnHitEvent()
    {
        if (_lockTarget!=null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            Manager.Sound.Play("Sounds/univ0001", Define.Sound.Effect);
            targetStat.OnAttack(_stat);
        }
        if (_stopSkill)
        {
            State = Define.State.Idle;
        }
        else
        {
            State = Define.State.Moving;
        }
    }
    
    private void OnMouseEvent(Define.MouseEvent evt)
    {
        if (State ==Define.State.Die)
            return;

        switch (State)
        {
            case Define.State.Idle:
                OnMouseEvent_IdleRun(evt);
                break;
            
            case Define.State.Moving:
                OnMouseEvent_IdleRun(evt);
                break;
            case Define.State.Skill:
                if (evt == Define.MouseEvent.PointerUp)
                {
                    _stopSkill = true; 
                }
                break;
        }
    }
    private void OnMouseEvent_IdleRun(Define.MouseEvent evt)
    {
        if (State == Define.State.Die)
            return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool ratcastHit = Physics.Raycast(ray, out hit, 100, _mask);
        switch (evt)
        {
            case Define.MouseEvent.PointerDown :
                if (ratcastHit)
                {
                     _destPos = hit.point;
                     State = Define.State.Moving;
                     _stopSkill = false;
                     
                     if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
                         _lockTarget = hit.collider.gameObject;
                     else
                         _lockTarget = null;
                }   
                break;
            case Define.MouseEvent.Press:

                if(_lockTarget == null && ratcastHit)
                    _destPos = hit.point;
                break;
            case Define.MouseEvent.PointerUp:
                _stopSkill = true;
                break;
        }
    }
}
