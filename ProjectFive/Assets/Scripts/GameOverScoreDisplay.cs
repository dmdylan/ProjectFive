using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreDisplay : MonoBehaviour
{
    public IntReference playerPoints;
    [SerializeField] private TextMeshProUGUI pointsText = null;

    void Start()
    {
        UpdatePlayerScore();
    }

    void UpdatePlayerScore()
    {
        string pointText;
        int playerScore = playerPoints.Value;
        pointText = string.Format("Points:{0:D4}", playerScore);
        pointsText.text = pointText;
    }
}
