using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreManager scoreManager;

    private void OnEnable()
    {
        scoreManager.OnScoreChanged.AddListener(UpdateScoreText);
        UpdateScoreText(scoreManager.currentScore);
    }
    private void OnDisable()
    {
        scoreManager.OnScoreChanged.RemoveListener(UpdateScoreText);
    }
    private void UpdateScoreText(float score)
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
}