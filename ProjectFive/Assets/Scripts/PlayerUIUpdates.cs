﻿using TMPro;
using UnityEngine;

public class PlayerUIUpdates : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText = null;
    public IntReference playerPoints;

    // Update is called once per frame
    void Update()
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
