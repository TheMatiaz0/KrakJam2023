using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D body;
    
    public float speed = 1;
    public float jump = 2;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards (transform.position, new Vector2(PlayerInstance.Current.transform.position.x, transform.position.y), speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // body.velocity = Vector2.up * jump;
    }
}
