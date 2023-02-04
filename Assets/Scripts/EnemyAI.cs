using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rgbd;
    
    public float speed = 1;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rgbd.transform.position += new Vector3(PlayerInstance.Current.transform.position.x-rgbd.transform.position.x, 0, 0) * (Time.deltaTime * speed);
    }
}
