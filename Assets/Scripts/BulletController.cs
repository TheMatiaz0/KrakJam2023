using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletTimeToDisappear;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, this.transform.rotation);
            var rb2D = bullet.GetComponent<Rigidbody2D>();
            rb2D.AddForce(bullet.transform.right * bulletSpeed, ForceMode2D.Impulse);
            StartCoroutine(DestroyBullet(bullet));
        }
    }

    private IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletTimeToDisappear);
        Destroy(bullet);
    }
}
