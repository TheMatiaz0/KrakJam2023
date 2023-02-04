using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletTimeToDisappear;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var bullet = Instantiate(bulletPrefab, firePoint.position, this.transform.rotation);
        bullet.Owner = this.gameObject;
        bullet.Rb2D.AddForce(bullet.transform.right * bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(DestroyBullet(bullet.gameObject));
    }

    private IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletTimeToDisappear);
        Destroy(bullet);
    }
}
