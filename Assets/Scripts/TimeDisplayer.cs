using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer : MonoBehaviour
{
    [SerializeField] private Text timeText;

    private void Update()
    {
        var p1 = TimeSpan.FromSeconds(LevelController.Current.WinTimer);
        var p2 = TimeSpan.FromMinutes(LevelController.Current.WinTimerThreshold / 60);
        var dt = (p2 - p1);
        if (dt.Seconds >= 0)
        {
            timeText.text = $"Survive {dt.ToString(@"mm\:ss\.fff")}";
        }
        else
        {
            timeText.text = "Kill all enemies";
        }
    }
}
