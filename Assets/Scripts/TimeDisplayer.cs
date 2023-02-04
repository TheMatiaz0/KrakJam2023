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
        // var p = new TimeSpan(minutes: 15);
        // timeText.text = lvlController.WinTimer.ToString("HH:mm:ss.fff");
    }
}
