using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayer : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private LevelController lvlController;

    private void Update()
    {
        var p1 = TimeSpan.FromSeconds(lvlController.WinTimer);
        var p2 = TimeSpan.FromMinutes(lvlController.WinTimerThreshold / 60);
        var dt = (p2 - p1);
        if (dt.Seconds >= 0)
        {
            timeText.text = dt.ToString(@"mm\:ss\.fff");
        }
        else
        {
            timeText.text = "";
        }
    }
}
