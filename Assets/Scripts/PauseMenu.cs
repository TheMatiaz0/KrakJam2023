using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private LevelController lvlController;
    [SerializeField] private GameObject main;
    [SerializeField] private Text titleText;

    [SerializeField] private string victoryMessage = "You have survived the waves";
    [SerializeField] private string failureMessage = "You have been limbed out";

    private void Start()
    {
        Time.timeScale = 1;
        lvlController.OnVictory += SetupVictory;
        HpEntity.OnPlayerDied += SetupFailure;
    }

    private void OnDestroy()
    {
        lvlController.OnVictory -= SetupVictory;
        HpEntity.OnPlayerDied -= SetupFailure;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetupVictory()
    {
        titleText.text = victoryMessage;
        SetupUI(true);
    }

    public void SetupFailure()
    {
        titleText.text = failureMessage;
        SetupUI(true);
    }

    private void SetupUI(bool isTrue)
    {
        main.SetActive(isTrue);
        Time.timeScale = isTrue ? 0 : 1;
    }
}
