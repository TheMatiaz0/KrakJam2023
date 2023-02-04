using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEntity : MonoBehaviour
{
    [SerializeField] private int maxHp;

    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            if (_hp <= 0)
            {
                Death();
            }
        }
    }

    private void Start()
    {
        Hp = maxHp;
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
