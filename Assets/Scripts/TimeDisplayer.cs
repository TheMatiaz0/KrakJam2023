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
        // why this piece of shit doesn't always work like it should
        var p1 = TimeSpan.FromSeconds(lvlController.WinTimer);
        var p2 = TimeSpan.FromMinutes(15);
        timeText.text = (p2 - p1).ToString();
    }
}
