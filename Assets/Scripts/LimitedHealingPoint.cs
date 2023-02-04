using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedHealingPoint : MonoBehaviour
{
    [SerializeField] private int capacity = 20;

    private Coroutine healCoroutine;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (healCoroutine == null)
            healCoroutine = StartCoroutine(HealWithCooldown(other));

    }

    private IEnumerator HealWithCooldown(Collider2D other)
    {
        if (other.TryGetComponent<HpEntity>(out var entity) && other.gameObject.CompareTag("Player"))
        {
            entity.Hp += 1;
            yield return new WaitForSeconds(1);
        }

        healCoroutine = null;

    }
    
    
    
}
