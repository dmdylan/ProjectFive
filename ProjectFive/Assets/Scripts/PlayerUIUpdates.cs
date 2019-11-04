using TMPro;
using UnityEngine;

public class PlayerUIUpdates : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = player.playerPoints.ToString();
        playerHealthText.text = player.playerCurrentHealth.ToString("Health: 20");
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerScore();
        UpdatePlayerHealthText();
    }

    void UpdatePlayerScore()
    {
        string pointText;
        int playerScore = player.playerPoints;
        pointText = string.Format("Points: {0}", playerScore);
        pointsText.text = player.playerPoints.ToString();
    }

    void UpdatePlayerHealthText()
    {
        string healthText;
        int playerHealthValue = player.playerCurrentHealth;
        healthText = string.Format("Health: {0}", playerHealthValue);
        playerHealthText.text = healthText;
    }
}
