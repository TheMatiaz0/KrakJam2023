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
        
        timeText.text = lvlController.WinTimer;
    }
}
