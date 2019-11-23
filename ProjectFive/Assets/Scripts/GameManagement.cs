using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    private bool theGameIsNotOver = true;
    public static int playerTotalPoints;
    public static bool playerPickedUpPowerUp = false;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar timeSlowEnergyBar;
    public SimpleHealthBar teleportEnergyBar;
    public IntReference playerPoints;
    public FloatReference gameTimer;
    public FloatReference playerFireRate;
    public FloatReference powerUpTimer;

    [SerializeField] private static float powerUpSpawnTimer = 45f;

    [SerializeField] GameObject powerUpObject = null;
    // Start is called before the first frame update
    void Awake()
    {
        playerPoints.Value = 0;
        gameTimer.Value = 0;
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
        UpdateTheGameTimer();
        PlayerPickedUpPowerUp();
        PowerUpSpawnCountDown();
    }

    private void ChangeGameState()
    {
        switch (theGameIsNotOver)
        {
            case true:
                break;
            case false:
                SetHighScore();
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

    private void UpdateTheGameTimer()
    {
        gameTimer.Value += Time.deltaTime;
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
    
    private void SetHighScore()
    {
        if (playerPoints.Value > PlayerPrefs.GetInt("Highscore"))
        { 
            PlayerPrefs.SetInt("Highscore", playerPoints.Value);
        }
    }

    private void PlayerPickedUpPowerUp()
    {
        if (playerPickedUpPowerUp == true)
        {
            powerUpTimer.Value -= Time.deltaTime;
            playerFireRate.Value = .06f;
            if(powerUpTimer.Value < 0)
            {
                playerPickedUpPowerUp = false;
                playerFireRate.Value = .12f;
                powerUpTimer.Value = 5f;
            }
        }
    }

    private void PowerUpSpawnCountDown()
    {
        if(powerUpSpawnTimer >= 0)
        {
            powerUpSpawnTimer -= Time.deltaTime;
        }
        else
        {
            powerUpSpawnTimer = 45f;
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    { 
        Instantiate(powerUpObject, new Vector3(0,.25f,0), transform.rotation);
    }
}
