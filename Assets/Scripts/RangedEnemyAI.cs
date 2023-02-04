using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : EnemyAI
{
    [SerializeField] private float maxDelta = 5;
    
    public override bool ShouldUpdate()
    {
        return base.ShouldUpdate() && GetDelta() > maxDelta;
    }

    public override void Flee()
    {
        // FLEE HERE
    }

    private float GetDelta()
    {
        return Mathf.Abs(PlayerInstance.Current.transform.position.x - this.transform.position.x);
    }
}
