using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEntity : MonoBehaviour
{
    [SerializeField] private int maxHp = 2;

    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            #if UNITY_EDITOR
            Debug.Log($"{this.gameObject.name} has now <color=red>{value} HP</color>", this.gameObject);
            #endif
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
