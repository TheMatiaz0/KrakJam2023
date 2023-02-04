using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : EnemyAI
{
    public override bool ShouldUpdate()
    {
        return base.ShouldUpdate() && GetDelta() > 5;
    }

    public override void Flee()
    {
        // FLEE HERE
    }

    private float GetDelta()
    {
        return (PlayerInstance.Current.transform.position.x - this.transform.position.x);
    }
}
