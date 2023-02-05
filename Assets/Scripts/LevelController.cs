using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public event Action OnVictory;
    [SerializeField] private float winTimerThreshold = 300;

    private bool _done;
    public bool timerDone
    {
        get => _done;
    }

    public float WinTimer { get; private set; }
    
    void Update()
    {
        if (WinTimer >= winTimerThreshold && !_done)
        {
            _done = true;
            GetComponentInChildren<SpawnerGroup>().gameObject.SetActive(false);
        }

        if (_done && GameObject.FindGameObjectsWithTag("Enemi").Length == 0)
        {
            OnVictory?.Invoke();
        }

        WinTimer += Time.deltaTime;
    }
}
