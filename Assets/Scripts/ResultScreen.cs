using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        scoreText.text = "Final Score: " + scoreManager.currentScore.ToString("0");
    }
}