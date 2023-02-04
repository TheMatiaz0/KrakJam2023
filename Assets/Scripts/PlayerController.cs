using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float treeRatio = 0.1f;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float minSpeed = 0.1f;
    [SerializeField] private float initialJump = 3;
    [SerializeField] private float jumpStrength = 4;
    // The time space is held affects jump height.
    [SerializeField] private float jumpGranuality = 20;
    
    private Rigidbody2D body;
    private int framesSinceFloor = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        framesSinceFloor = 0;
    }

    void Update()
    {
        var speed = Mathf.Lerp(maxSpeed, minSpeed, treeRatio);
        
        body.velocity = new Vector2(0, body.velocity.y);
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.Space) && framesSinceFloor == 0)
        {
            body.velocity = Vector2.up * initialJump;
        }
        else if (Input.GetKey(KeyCode.Space) && framesSinceFloor < jumpGranuality)
        {
            body.velocity += Vector2.up * (jumpStrength / jumpGranuality);
        }
        
        framesSinceFloor += 1;
    }
}
