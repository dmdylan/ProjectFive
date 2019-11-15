using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreDisplay : MonoBehaviour
{
    public IntReference playerPoints;
    [SerializeField] private TextMeshProUGUI pointsText = null;
    [SerializeField] private TextMeshProUGUI highScoreTextUI = null;

    void Start()
    {
        UpdatePlayerScore();
        UpdatePlayerHighScore();
    }

    private void UpdatePlayerHighScore()
    {
        string highScoreText;
        int playerHighScore = PlayerPrefs.GetInt("Highscore");
        highScoreText = string.Format("High Score:{0:D4}", playerHighScore);
        highScoreTextUI.text = highScoreText;
    }

    void UpdatePlayerScore()
    {
        string pointText;
        int playerScore = playerPoints.Value;
        pointText = string.Format("Points:{0:D4}", playerScore);
        pointsText.text = pointText;
    }
}
