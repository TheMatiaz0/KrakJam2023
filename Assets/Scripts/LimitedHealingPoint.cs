using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LimitedHealingPoint : MonoBehaviour
{
    [SerializeField] private float capacity = 20;
    [SerializeField] private float cooldown = 50f;
    [SerializeField] private float healRate = 1f;
    [SerializeField] private float refresh = 10f;
    [SerializeField] private SpriteRenderer root;

    private Coroutine healCoroutine;
    private bool playerIn;
    private Collider2D playerCol;
    private ParticleSystem particles;
    private float initCapacity;
    private AudioSource sound;
    private bool depleted = false;

    private void Start()
    {
        initCapacity = capacity;
        sound = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (playerIn && healCoroutine == null)
            healCoroutine = StartCoroutine(HealWithCooldown(playerCol));
        if(!playerIn)
            root?.material.DOFloat(depleted ? -0.5f : 0, "_Grow", 1).SetLink(this.gameObject);
         
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        playerIn = true;
        playerCol = col;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        playerIn = true;
        playerCol = col;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        playerIn = false;
        sound.Stop();
    }

    private IEnumerator HealWithCooldown(Collider2D other)
    {
        if (other == null || PlayerInstance.Current == null) yield break;
        if (other.TryGetComponent<HpEntity>(out var entity) && other.gameObject == PlayerInstance.Current.gameObject)
        {
            if (capacity > 0)
            {
                if (!sound.isPlaying)
                {
                    root?.material.DOFloat(1, "_Grow", 2);
                    
                    sound.Play();
                }

                var change = healRate * (cooldown / 1000);
                entity.Hp += change;
                capacity -= change;
            }
            else
            {
                depleted = true;
                root?.material.DOFloat(-0.5f, "_Grow", 1);
                
                sound.Stop();
                particles.Stop();
                yield return new WaitForSeconds(refresh);
                depleted = false;
                capacity = initCapacity;
                particles.Play();
                
            }
            yield return new WaitForSeconds(cooldown / 1000);
        }

        healCoroutine = null;

    }
    
    
    
}
