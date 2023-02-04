using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHpTaker : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float cooldown = 0.5f;

    private Coroutine damageCoroutine;
    
    private void OnCollisionStay2D(Collision2D col)
    {
        if (damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(DamageWithDelay(col));
        }
    }

    private IEnumerator DamageWithDelay(Collision2D col)
    {
        var colObj = col.gameObject;
        if (colObj.TryGetComponent<HpEntity>(out var entity) && colObj.GetComponent<PlayerInstance>() != null)
        {
            entity.Hp -= damage;
            yield return new WaitForSeconds(cooldown);
        }

        damageCoroutine = null;
    }
}
