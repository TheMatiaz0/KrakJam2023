using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float initialJump = 3;
    [SerializeField] private float jumpStrength = 4;
    // The time space is held affects jump height.
    [SerializeField] private float jumpGranuality = 20;

    private Rigidbody2D body;
    private BoxCollider2D jumpResetCollider;
    private int framesSinceFloor = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpResetCollider = GetComponentInChildren<BoxCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D col = collision.GetContact(0).otherCollider;
        if (col == jumpResetCollider)
        {
            framesSinceFloor = 0;
        }
    }

    void Update()
    {
        var dt = Time.deltaTime;
        
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * (speed * dt);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * (speed * dt);
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
