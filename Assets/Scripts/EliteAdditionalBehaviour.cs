using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EliteAdditionalBehaviour : MonoBehaviour
{
    [SerializeField] private LimitedHealingPoint healingPointPrefab;

    [SerializeField] private float timeToDisappearHealing = 2;
    [SerializeField] private float timeForDynamicDrop = 1;

    private void Start()
    {
        HpEntity.OnEnemyDied += OnEnemyDied;
    }

    private void OnDestroy()
    {
        HpEntity.OnEnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(HpEntity entity)
    {
        if (entity == this.GetComponent<HpEntity>())
        {
            var healingPoint = Instantiate(healingPointPrefab, this.transform.position, Quaternion.identity);
            var col = healingPoint.GetComponent<Collider2D>();
            var rb2D = healingPoint.GetComponent<Rigidbody2D>();
            col.isTrigger = false;
            rb2D.isKinematic = false;
            DOVirtual.DelayedCall/*jebac unity |: */(timeForDynamicDrop, () =>
            {
                col.isTrigger = true;
                rb2D.isKinematic = true;
            });
            DOVirtual.DelayedCall/*jebac unity |: */(timeToDisappearHealing, () =>
            {
                Destroy(healingPoint.gameObject);
            });
        }
    }
}
