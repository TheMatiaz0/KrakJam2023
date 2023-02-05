using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private int scoreForKilling = 10;
    [SerializeField] private float scoreScaleDuration = 6;
    [SerializeField] private float scoreAnimationMultiplier = 1.2f;

    private Vector2 cachedScale;

    private int _scorePoints;
    private int ScorePoints
    {
        get => _scorePoints;
        set
        {
            _scorePoints = value;
            scoreText.rectTransform.DOScale(
                new Vector2(scoreText.rectTransform.localScale.x * scoreAnimationMultiplier, 
                    scoreText.rectTransform.localScale.y * scoreAnimationMultiplier), 
                scoreScaleDuration / 2).OnComplete(() =>
            {
                scoreText.rectTransform.DOScale(cachedScale , scoreScaleDuration / 2);
            }).SetLink(this.gameObject);
            scoreText.text = value.ToString();
        }
    }

    private void Start()
    {
        cachedScale = scoreText.rectTransform.localScale;
        ScorePoints = 0;
        HpEntity.OnEnemyDied += OnEnemyDied;
    }

    private void OnDestroy()
    {
        HpEntity.OnEnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(HpEntity _)
    {
        ScorePoints += scoreForKilling;
    }
}
