using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rgbd;
    public Transform PlayerTransform;
    public float speed = 1;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rgbd.transform.position += new Vector3(PlayerTransform.transform.position.x-rgbd.transform.position.x, 0, 0) * (Time.deltaTime * speed);
    }
}
