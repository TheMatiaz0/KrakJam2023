using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string destinationScene;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(destinationScene);
    }
}
