using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private bool theGameIsNotOver = true;
    public static bool gameIsPaused = false;
    public static int playerTotalPoints;
    public static bool playerPickedUpPowerUp = false;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar timeSlowEnergyBar;
    public SimpleHealthBar teleportEnergyBar;
    public IntReference playerPoints;
    public FloatReference gameTimer;
    public FloatReference playerFireRate;
    public FloatReference powerUpTimer;
    public FloatReference enemySpawnRate;
    public static bool gameIsNotPaused;

    public GameObject pausePanel;

    [SerializeField] private static float powerUpSpawnTimer = 45f;

    [SerializeField] GameObject powerUpObject = null;
    // Start is called before the first frame update
    void Awake()
    {
        powerUpSpawnTimer = 45f;
        enemySpawnRate.Value = .6f;
        playerPoints.Value = 0;
        gameTimer.Value = 0;
        playerFireRate.Value = .12f;
        Player.playerCurrentHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        PauseTheGame();
        IsThePlayerIsDead();
        ChangeGameState();
        UpdateHealthBar();
        UpdateTimeSlowEnergyBar();
        UpdateTeleportRechargeBar();
        UpdateTheGameTimer();
        PlayerPickedUpPowerUp();
        PowerUpSpawnCountDown();
        IncreaseEnemySpawnRate();
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
        Initiate.Fade("GameOver", Color.black, 3f);
    }

    private void IsThePlayerIsDead()
    {
        if (Player.playerCurrentHealth <= 0)
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
            if (powerUpTimer.Value < 0)
            {
                playerPickedUpPowerUp = false;
                playerFireRate.Value = .12f;
                powerUpTimer.Value = 7f;
            }
        }
    }

    private void PowerUpSpawnCountDown()
    {
        if (powerUpSpawnTimer >= 0)
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
        Instantiate(powerUpObject, new Vector3(0, .25f, 0), transform.rotation);
    }

    private void IncreaseEnemySpawnRate()
    {
        if (gameTimer.Value >= 60 && gameTimer.Value <= 120)
        {
            enemySpawnRate.Value = .5f;
        }
        else if (gameTimer.Value >= 120 && gameTimer.Value <= 180)
        {
            enemySpawnRate.Value = .4f;
        }
        else if (gameTimer.Value >= 180 && gameTimer.Value <= 240)
        {
            enemySpawnRate.Value = .3f;
        }
        else if (gameTimer.Value >= 240 && gameTimer.Value <= 300)
        {
            enemySpawnRate.Value = .2f;
        }
        else if (gameTimer.Value >= 300)
        {
            enemySpawnRate.Value = .1f;
        }
    }

    public void PauseTheGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused == false)
        {
            gameIsPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gameIsPaused == true)
        {
            gameIsPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}
