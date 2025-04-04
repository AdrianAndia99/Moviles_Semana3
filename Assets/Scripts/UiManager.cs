using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public ScoreManager scoreData;
    public HealthManager healthData;

    private void Update()
    {
        scoreText.text = "Score: " + scoreData.currentScore.ToString("F1");
        healthText.text = "Health: " + healthData.currentHealth.ToString("F0");
    }
}