using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    private bool theGameIsNotOver = true;
    Player player;
    public int playerScoreUI;
    Enemy enemies;

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<Player>();
        enemies = FindObjectOfType<Enemy>();
        player.playerPoints = 0;
        player.playerCurrentHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        IsThePlayerIsDead();
        ChangeGameState();
        UpdatePlayerScore();
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

    private void UpdatePlayerScore()
    {
        if(enemies.enemyHealth == 0)
        {
            player.playerPoints += 5;
        }
    }
}
