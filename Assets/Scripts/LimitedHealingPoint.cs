using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedHealingPoint : MonoBehaviour
{
    [SerializeField] private float capacity = 20;
    [SerializeField] private float cooldown = 50f;
    [SerializeField] private float healRate = 1f;

    private Coroutine healCoroutine;
    private bool playerIn;
    private Collider2D playerCol;
    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (playerIn && healCoroutine == null)
            healCoroutine = StartCoroutine(HealWithCooldown(playerCol));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        playerIn = true;
        playerCol = col;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerIn = false;
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
            else
            {
                particles.Stop();
            }
            yield return new WaitForSeconds(cooldown / 1000);
        }

        healCoroutine = null;

    }
    
    
    
}
