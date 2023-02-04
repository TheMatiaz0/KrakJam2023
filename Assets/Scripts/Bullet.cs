using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event Action OnCollision;

    [SerializeField] private Rigidbody2D rb2D;
    public Rigidbody2D Rb2D => rb2D;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        OnCollision?.Invoke();
    }
}
