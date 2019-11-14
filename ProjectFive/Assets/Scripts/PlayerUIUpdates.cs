using TMPro;
using UnityEngine;
using System;

public class PlayerUIUpdates : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText = null;
    [SerializeField] private TextMeshProUGUI gameTimeText;
    public IntReference playerPoints;
    public FloatReference gameTimer;

    private void Start()
    {
        gameTimeText.text = gameTimer.Value.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerScore();
        UpdateGameTimer();
    }

    void UpdatePlayerScore()
    {
        string pointText;
        int playerScore = playerPoints.Value;
        pointText = string.Format("Points:{0:D4}", playerScore);
        pointsText.text = pointText;
    }

    private void UpdateGameTimer()
    {    
        gameTimeText.text = FormatSeconds(gameTimer.Value);
    }        

    private string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }
}
