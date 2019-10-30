using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    private bool theGameIsNotOver = true;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        IsThePlayerIsDead();
        ChangeGameState();
    }

    private void ChangeGameState()
    {
        switch (theGameIsNotOver)
        {
            case true:
                break;
            case false:
                GameOverSequence();
                break;
        }
    }

    private void GameOverSequence()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void IsThePlayerIsDead()
    {
        if(player.playerCurrentHealth <= 0)
        {
            theGameIsNotOver = false;
        }
    }
}
