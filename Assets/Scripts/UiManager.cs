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
        scoreText.text = "Puntos: " + scoreData.currentScore.ToString("F1");
        healthText.text = "Vida: " + healthData.currentHealth.ToString("F0");
    }
}