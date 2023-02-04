using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    public Rigidbody2D Rb2D => rb2D;

    public GameObject Owner { get; set; }
    public int Damage { get; set; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != Owner)
        {
            Destroy(this.gameObject);
            if (col.TryGetComponent<HpEntity>(out var entity))
            {
                entity.Hp -= Damage;
            }
        }
    }
}
