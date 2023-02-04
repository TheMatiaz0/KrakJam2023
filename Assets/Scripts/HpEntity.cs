using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEntity : MonoBehaviour
{
    [SerializeField] private int maxHp = 2;
    [SerializeField] private int startHp = 2;

    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            #if UNITY_EDITOR
            Debug.Log($"{this.gameObject.name} has now <color=red>{value} HP</color>", this.gameObject);
            #endif
            _hp = Mathf.Clamp(value, 0, maxHp);
            if (_hp <= 0)
            {
                Death();
            }
        }
    }

    public int HpMax
    {
        get => maxHp;
    }

    private void Start()
    {
        Hp = startHp;
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
