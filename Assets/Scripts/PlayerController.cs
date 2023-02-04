using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float minSpeed = 0.1f;
    [SerializeField] private float initialJump = 3;
    [SerializeField] private float jumpStrength = 4;
    // The time space is held affects jump height.
    [SerializeField] private float jumpGranuality = 20;
    [SerializeField] private SpriteRenderer armSprite;
    
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private HpEntity hp;
    private int framesSinceFloor = 0;
    private Animator anim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        hp = GetComponent<HpEntity>();
        anim = GetComponentInChildren<Animator>();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        framesSinceFloor = 0;
    }

    void Update()
    {
        #if UNITY_EDITOR || DEVELOPMENT_BUILD
        
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
        #endif
        
        var jumpBoost = (0.5f - hp.Hp / hp.HpMax) * 2;
        var speed = Mathf.Lerp(maxSpeed, minSpeed, hp.Hp / hp.HpMax);
        anim.speed = 1 - (hp.Hp / hp.HpMax);
       
        body.velocity = new Vector2(0, body.velocity.y);
        bool walking = false;
        if (Input.GetKey(KeyCode.D))
        {
            walking = true;
            anim.Play("Walk");
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            walking = true;
            anim.Play("Walk");
            body.velocity = new Vector2(-speed, body.velocity.y);
        }

        if (!walking)
        {
            anim.Play("Idle");
        }
        
        if (Input.GetKey(KeyCode.Space) && framesSinceFloor == 0)
        {
            body.velocity = Vector2.up * (initialJump + jumpBoost);
        }
        else if (Input.GetKey(KeyCode.Space) && framesSinceFloor < jumpGranuality)
        {
            body.velocity += Vector2.up * (jumpStrength / jumpGranuality);
        }
        
        framesSinceFloor += 1;

        float progress = hp.Hp / hp.HpMax;
        float armStart = 0.6f;
        sprite.material.SetFloat("_Blend", progress);
        armSprite.material.SetFloat("_Blend", (progress - armStart) / (1-armStart));
    }
}
