using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string destinationScene;
    
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
