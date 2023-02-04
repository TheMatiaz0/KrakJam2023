using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private int scoreForKilling = 10;

    private int _scorePoints;
    private int ScorePoints
    {
        get => _scorePoints;
        set => _scorePoints = value;
    }

    private void Start()
    {
        HpEntity.OnEnemyDied += OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        // scorePoints += 1;
    }
}
