using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    public static PlayerInstance Current 
    {
        get;
        private set;
    }

    private void Awake()
    {
        Current = this;
    }
}
