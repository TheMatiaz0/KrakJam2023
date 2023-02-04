using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedHealingPoint : MonoBehaviour
{
    [SerializeField] private int capacity = 20;
    [SerializeField] private float cooldown = 1f;

    private Coroutine healCoroutine;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (healCoroutine == null)
            healCoroutine = StartCoroutine(HealWithCooldown(other));

    }

    private IEnumerator HealWithCooldown(Collider2D other)
    {
        if (other.TryGetComponent<HpEntity>(out var entity) && other.gameObject == PlayerInstance.Current.gameObject)
        {
            if (capacity > 0)
            {
                entity.Hp++;
                capacity--;
            }
            yield return new WaitForSeconds(cooldown);
        }

        healCoroutine = null;

    }
    
    
    
}
