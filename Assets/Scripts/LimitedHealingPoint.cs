using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedHealingPoint : MonoBehaviour
{
    [SerializeField] private float capacity = 20;
    [SerializeField] private float cooldown = 100f;
    [SerializeField] private float healRate = 1f;

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
                var change = healRate * (cooldown / 1000);
                entity.Hp += change;
                capacity -= change;
            }
            yield return new WaitForSeconds(cooldown / 1000);
        }

        healCoroutine = null;

    }
    
    
    
}
