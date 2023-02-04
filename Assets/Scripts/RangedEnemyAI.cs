using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : EnemyAI
{
    [SerializeField] private float maxDelta = 5;
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private BulletController bulletController;

    private Coroutine shootCoroutine;
    
    public override bool ShouldUpdate()
    {
        return base.ShouldUpdate() && GetDelta() > maxDelta;
    }

    public override void Flee()
    {
        var dt = -(PlayerInstance.Current.transform.position.x - this.transform.position.x);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(dt, transform.position.y), speed * Time.deltaTime);
    }

    public override void ExtendUpdate()
    {
        if (shootCoroutine == null)
        {
            shootCoroutine = StartCoroutine(ShootWithCooldown());
        }
    }

    private float GetDelta()
    {
        return Mathf.Abs(PlayerInstance.Current.transform.position.x - this.transform.position.x);
    }

    private IEnumerator ShootWithCooldown()
    {
        Shoot();
        yield return new WaitForSeconds(2);
        shootCoroutine = null;
    }

    private void Shoot()
    {
        bulletController.Shoot(false);
    }
}
