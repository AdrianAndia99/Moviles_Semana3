using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    public TextMeshPro scoreText;
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreText.text = "Final Score: " + scoreManager.currentScore.ToString("0");
    }
}
