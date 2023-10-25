using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Stat : MonoBehaviour
{
   [FormerlySerializedAs("_levevl")] [SerializeField]protected int _level;
   [FormerlySerializedAs("_Hp")] [SerializeField]protected int _hp;
   [SerializeField]protected int _maxHp;
   
   [FormerlySerializedAs("_Attack")] [SerializeField]protected int _attack;
   [FormerlySerializedAs("_Defense")] [SerializeField]protected int _defense;
   
   [FormerlySerializedAs("_MoveSpeed")] [SerializeField]protected float _moveSpeed;

   public int Level { get { return _level;} set { _level = value; } }
   public int Hp { get { return _hp;} set { _hp = value; } }
   public int maxHp { get { return _maxHp;} set { _maxHp = value; } }
   public int Attack { get { return _attack;} set { _attack = value; } }
   public int Defense { get { return _defense;} set { _defense = value; } }
   public float Movespeed { get { return _moveSpeed;} set { _moveSpeed = value; } }

   

   private void Start()
   {
      _moveSpeed = 3.0f;
      _level = 1;
      _maxHp = 100;
      _hp = 100;
      _attack = 10;
      _defense = 5;
   }

   public virtual void OnAttack(Stat attacker)
   {
      int damage = Mathf.Max(0, attacker.Attack - _defense);
      Hp -= damage;
      if (Hp<=0)
      {
         Hp = 0;
         OnDead(attacker);
      }
   }

   protected virtual void OnDead(Stat attacker)
   {
      PlayerStat playerStat = attacker as PlayerStat;
      if (playerStat != null)
      {
         playerStat.Exp += 15;
      }
      Manager.Game.Despawn(gameObject);
   }
}
