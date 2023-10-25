using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField] protected int _exp;
    [SerializeField] protected int _gold;

    public int Exp 
    {   get { return _exp;}
        set
        {
            _exp = value;
            _exp = value;
            int level = Level;
            while (true)
            {
                Data.Stat stat;
                if (Manager.Data.StatDict.TryGetValue(level + 1, out stat) == false)
                    break;
                if (_exp < stat.totlaExp)
                    break;
                level++;
            }

            if (level != Level)
            {
                Debug.Log("Level Up");
                Level = level;
                SetStat(Level);
            }
        }
    }
    public int Gold { get { return _gold;} set { _gold = value; } }
    

    private void Start()
    {
        _level = 1;
        _hp = 200;
        _maxHp = 200;
        _attack = 10;
        _defense = 7;
        _moveSpeed = 5.0f;
        _exp = 0;
        _gold = 0;

        SetStat(_level);
    }

    private void SetStat(int level)
    {
        Dictionary<int, Data.Stat> dic = Manager.Data.StatDict;
        Data.Stat stat = dic[level];

        _hp = stat.maxHp;
        _maxHp = stat.maxHp;
        _attack = stat.attack;
    }

    protected override void OnDead(Stat attacker)
    {
       Debug.Log("Player Dead");
       Manager.Game.Despawn(gameObject);
       
    }

}
