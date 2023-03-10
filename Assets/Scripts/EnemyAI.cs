using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public float minSpeed = 1;
    public float maxSpeed = 4;
    public float jump = 2;
    public float jumpCooldown = 2;
    
    private Rigidbody2D body;
    private Coroutine jumpCoroutine;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (ShouldUpdate())
        {
            transform.position = Vector2.MoveTowards (transform.position, 
                new Vector2(PlayerInstance.Current.transform.position.x, transform.position.y), 
                Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
        }
        else
        {
            Flee();
        }

        ExtendUpdate();
    }

    public virtual void ExtendUpdate()
    {
        
    }

    // TODO: Refactor this shit into abstract class some time later when there will be time.
    public virtual bool ShouldUpdate()
    {
        return PlayerInstance.Current != null;
    }

    public virtual void Flee()
    {
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (jumpCoroutine == null)
        {
            jumpCoroutine = StartCoroutine(JumpWithDelay(col));
        }
    }

    private IEnumerator JumpWithDelay(Collider2D col)
    {
        if (col.gameObject.CompareTag("Trigger"))
        {
            body.velocity = Vector2.up * jump;
            yield return new WaitForSeconds(jumpCooldown);
        }
        jumpCoroutine = null;
    }
}
