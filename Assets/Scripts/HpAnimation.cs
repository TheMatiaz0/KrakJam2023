using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HpAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float animHurtDuration;

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
            spriteRenderer.DOColor(Color.red, animHurtDuration).SetEase(Ease.InOutQuad)
                .OnComplete(() => spriteRenderer.DOColor(spriteColor, animHurtDuration).SetEase(Ease.InOutQuad)).SetLink(this.gameObject);
        }
    }
}
