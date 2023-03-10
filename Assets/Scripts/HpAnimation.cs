using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HpAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float animHurtDuration;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private Color colorOnHurt = Color.gray;

    private Color spriteColor;
    
    private void Start()
    {
        spriteColor = spriteRenderer.color;
        HpEntity.OnHurt += Hurt;
    }

    private void OnDestroy()
    {
        HpEntity.OnHurt -= Hurt;
    }

    private void Hurt(HpEntity entity)
    {
        if (entity == this.GetComponent<HpEntity>())
        {
            if (hurtSound != null)
            {
                soundSource.PlayOneShot(hurtSound);
            }

            if (spriteRenderer != null && spriteRenderer.gameObject != null)
                spriteRenderer.DOColor(colorOnHurt, animHurtDuration).SetEase(Ease.InOutQuad)
                .OnComplete(() => spriteRenderer.DOColor(spriteColor, animHurtDuration).SetEase(Ease.InOutQuad)).SetLink(this.gameObject);
        }
    }
}
