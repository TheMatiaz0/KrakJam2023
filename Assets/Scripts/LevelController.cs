using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public event Action OnVictory;
    public static LevelController Current { get; private set; }

    [SerializeField] private float winTimerThreshold = 180;
    public float WinTimerThreshold => winTimerThreshold;

    private bool _done;
    public bool timerDone
    {
        get => _done;
    }

    public float WinTimer { get; private set; }

    private void Awake()
    {
        Current = this;
    }

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
