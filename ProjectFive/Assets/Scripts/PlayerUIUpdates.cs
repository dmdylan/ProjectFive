using TMPro;
using UnityEngine;

public class PlayerUIUpdates : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerScore();
    }

    void UpdatePlayerScore()
    {
        string pointText;
        int playerScore = GameManagement.playerTotalPoints;
        pointText = string.Format("Points:{0:D4}", playerScore);
        pointsText.text = pointText;
    }
}
