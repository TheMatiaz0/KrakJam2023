using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHpTaker : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<HpEntity>(out var entity) && col.gameObject != this.gameObject)
        {
            entity.Hp -= damage;
        }
    }
}
