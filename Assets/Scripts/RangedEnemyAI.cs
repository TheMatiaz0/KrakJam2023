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
        var dt = -(PlayerInstance.Current.transform.position.x - this.transform.position.x);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(dt, transform.position.y), speed * Time.deltaTime);
    }

    private float GetDelta()
    {
        return Mathf.Abs(PlayerInstance.Current.transform.position.x - this.transform.position.x);
    }
}
