using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    private bool theGameIsNotOver = true;
    public static int playerTotalPoints;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar timeSlowEnergyBar;
    public SimpleHealthBar teleportEnergyBar;
    public IntReference playerPoints;
    // Start is called before the first frame update
    void Awake()
    {
        playerPoints.Value = 0;
        Player.playerCurrentHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        IsThePlayerIsDead();
        ChangeGameState();
        UpdateHealthBar();
        UpdateTimeSlowEnergyBar();
        UpdateTeleportRechargeBar();
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
        if(Player.playerCurrentHealth <= 0)
        {
            theGameIsNotOver = false;
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.UpdateBar(Player.playerCurrentHealth, Player.playerStartingHealth);
    }

    private void UpdateTimeSlowEnergyBar()
    {
        timeSlowEnergyBar.UpdateBar(Player.playerCurrentSlowTimeEnergy, Player.playerMaxSlowTimeEnergy);
    }

    private void UpdateTeleportRechargeBar()
    {
        teleportEnergyBar.UpdateBar(Player.playerTeleportTimer, 10f);
    }
}
