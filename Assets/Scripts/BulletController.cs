using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletSpeed = 200;
    [SerializeField] private float bulletTimeToDisappear = 1;
    [SerializeField] private int bulletDamage = 1;
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] private int bulletsCount;
    [SerializeField] private float spreadDegree = -21;

    private bool isInCooldown;
    
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0) || isInCooldown) return;
        for (int i = 0; i < bulletsCount; i++)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, this.transform.rotation);

            bullet.transform.Rotate(new Vector3(bullet.transform.rotation.x, bullet.transform.rotation.y, i * spreadDegree));
            
            bullet.Owner = this.gameObject;
            bullet.Damage = bulletDamage;
            bullet.Rb2D.AddForce(bullet.transform.right * bulletSpeed, ForceMode2D.Impulse);
            StartCoroutine(DestroyBullet(bullet.gameObject));
            Invoke(nameof(ResetCooldown), cooldown);
            isInCooldown = true;
        }
    }

    private void ResetCooldown()
    {
        isInCooldown = false;
    }

    private IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletTimeToDisappear);
        Destroy(bullet);
    }
}
