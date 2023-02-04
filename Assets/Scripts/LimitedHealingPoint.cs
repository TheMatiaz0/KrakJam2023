using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedHealingPoint : MonoBehaviour
{
    [SerializeField] private int capacity = 20;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // heal
        }
        
    }
    
    
    
}
