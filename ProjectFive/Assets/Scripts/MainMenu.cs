using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Initiate.Fade("Game", Color.black, 2f);
    }

    public void MenuScreen()
    {
        Time.timeScale = 1f;
        GameManagement.gameIsPaused = false;
        Initiate.Fade("Main Menu", Color.black, 1f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
