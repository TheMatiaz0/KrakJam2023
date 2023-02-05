using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;

    public static CinemachineShake Current { get; private set; }

    private float shakeTimer;

    private void Awake()
    {
        Current = this;
    }

    public void ShakeCamera(float intensity, float time)
    {
        var perlin = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                var perlin = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                perlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
