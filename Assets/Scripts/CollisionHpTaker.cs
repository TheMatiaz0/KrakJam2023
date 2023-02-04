using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHpTaker : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        var colObj = col.gameObject;
        if (colObj.TryGetComponent<HpEntity>(out var entity) && colObj.GetComponent<PlayerInstance>() != null)
        {
            entity.Hp -= damage;
        }
    }
}
