using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float winTimerThreshold = 300;

    private bool _done;
    public bool timerDone
    {
        get => _done;
    }
    private float winTimer = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (winTimer >= winTimerThreshold && !_done)
        {
            _done = true;
            //rób rzeczy
        }

        winTimer += Time.deltaTime;

    }
}
