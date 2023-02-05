using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteAdditionalBehaviour : MonoBehaviour
{
    [SerializeField] private LimitedHealingPoint healingPointPrefab;
    [SerializeField] private float kinematicDelay = 2;

    private Coroutine spawnHealingPointCoroutine;
    
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
        }
    }
}
