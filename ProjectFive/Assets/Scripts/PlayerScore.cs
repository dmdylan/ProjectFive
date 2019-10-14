using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text text;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        text.text = player.playerPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerScore();
    }

    void UpdatePlayerScore()
    {
        string pointText;
        int playerScore = player.playerPoints;
        pointText = string.Format("Points: {0}", playerScore);
        text.text = pointText;
    }
}
