using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class MonsterController : BaseController
{
    [SerializeField] private Stat _stat;
    private float _scanRange = 7;
    private float _attackRange = 2;

    void Start()
    {
        WorldobjectType = Define.Worldobject.Monster;
        _stat = gameObject.GetComponent<Stat>();
        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
        {
            Manager.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
        }
    }

    protected override void UpdateMoving()
    {
        _destPos = _lockTarget.transform.position;
        float distance = (_destPos - transform.position).magnitude;
        if (distance <= 1.5)
        {
            NavMeshAgent nma2 = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma2.SetDestination(transform.position);
            State = Define.State.Skill;
            return;
        }


        Vector3 dir = _destPos - transform.position;
        
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
            return;
        }

        NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
        nma.SetDestination(_destPos);
        nma.speed = _stat.Movespeed;
        

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 50 * Time.deltaTime);
        if (distance > _scanRange)
        {
            NavMeshAgent nma2 = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma2.SetDestination(transform.position);

            State = Define.State.Idle;
        }
    }

    protected override void UpdateIdle()
    {
        GameObject player = Manager.Game.GetPlayer();
        if (player == null)
            return;

        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= _scanRange)
        {
            _lockTarget = player;
            State = Define.State.Moving;
            return;
        }

        
       
    }


    protected override void UpdateSkill()
    {
        if (_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }

    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            targetStat.OnAttack(_stat);

            if (targetStat.Hp > 0)
            {
                float distance = (_destPos - transform.position).magnitude;
                if (distance <= _attackRange)
                    State = Define.State.Skill;
                else
                    State = Define.State.Moving;
            }
            else
            {
                State = Define.State.Idle;
            }
        }
        else
        {
            State = Define.State.Idle;
        }
    }
}
    
