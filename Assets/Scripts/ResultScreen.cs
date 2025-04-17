using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        //pruebas
    }
    private void Start()
    {
        scoreText.text = "Score: " + scoreManager.currentScore.ToString("0");
    }
}