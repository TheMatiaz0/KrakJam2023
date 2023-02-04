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
    [SerializeField] private ParticleSystem shootParticle;
    [SerializeField] private float particleTime = 0.3f;

    private Coroutine shootParticleCoroutine;
    private bool isInCooldown;

    private void Start()
    {
        if (shootParticle != null)
            shootParticle.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Shoot();
    }

    private IEnumerator ParticleWithCooldown()
    {
        yield return new WaitForSeconds(particleTime);
        if (shootParticle != null)
        {
            shootParticle.gameObject.SetActive(false);
            shootParticleCoroutine = null;
        }
    }

    public void Shoot()
    {
        if (isInCooldown) return;
        for (int i = 0; i < bulletsCount; i++)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, this.transform.rotation);

            bullet.transform.Rotate(new Vector3(0, 0, i * spreadDegree));

            if (shootParticle != null)
            {
                shootParticle.gameObject.SetActive(true);
                if (shootParticleCoroutine == null)
                    shootParticleCoroutine = StartCoroutine(ParticleWithCooldown());
            }

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
