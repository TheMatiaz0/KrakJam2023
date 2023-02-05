using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 initialArmPos;
    private bool facingRight = true;
    private void Start()
    {
        initialArmPos = transform.localPosition;
    }

    private void Update()
    {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (rotZ < -90  || rotZ > 90)
        {
            if (facingRight)
            {
                player.transform.position -= new Vector3(0.415f,0f,0f);
            }
            
            facingRight = false;
            spriteRenderer.flipX = true;
            transform.localPosition = new Vector3(-initialArmPos.x, initialArmPos.y, 0);
            if (player.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
            }  
            else if (player.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
            }
        }
        else
        {
            if (!facingRight)
            {
                player.transform.position += new Vector3(0.415f,0f,0f);
            }
            facingRight = true;
            spriteRenderer.flipX = false;
            transform.localPosition = initialArmPos;
        }
    }
}
