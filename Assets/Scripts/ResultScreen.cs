using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI maxScoreText;

    [SerializeField] private ScoreManager scoreManager;

    private void OnEnable()
    {
        //actualizar puntaje
        scoreManager.OnScoreChanged.AddListener(UpdateScoreText);
        UpdateScoreText(scoreManager.currentScore);

        //actualizar maximo puntaje
        scoreManager.OnHighScoreChanged.AddListener(UpdateHighScore);
        UpdateHighScore(scoreManager.highScore);

    }
    private void OnDisable()
    {
        scoreManager.OnScoreChanged.RemoveListener(UpdateScoreText);
        scoreManager.OnHighScoreChanged.RemoveListener(UpdateHighScore);
    }
    private void UpdateScoreText(float score)
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
    private void UpdateHighScore(float best)
    {
        maxScoreText.text = "Max Score: " + Mathf.FloorToInt(best);
    }
}