using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        
    }
    private void Start()
    {


        //scoreText.text = "Score: " + scoreManager.GetLastRecordedScore());
    }
    void OnEnable()
    {
        if(scoreManager.GetHighScoreTest() == true)
        {
            scoreText.text = "New High Score: " + Mathf.FloorToInt(scoreManager.currentScore);
            //Debug.Log("funciona");
        }
        else
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(scoreManager.currentScore);
        }
            // ScoreManager.OnScoreChange += UpdateScoreText;
            
       // Debug.Log("Score: " + scoreManager.currentScore);// se asigna una vez y se sigue imprimiendo lo mismo
        //scoreManager.GetHighScore();
    }
    void OnDisable()
    {
       // ScoreManager.OnScoreChange -= UpdateScoreText;
    }
    public void UpdateScoreText(float score)
    {
        //scoreText.text = "Score: " + Mathf.FloorToInt(score);
      //  Debug.Log( "Score: " + score);// no se imprime
        //scoreText.text = "Score: " + Mathf.FloorToInt(scoreManager.GetLastRecordedScore()); solo se asigna el primer valor y no actualiza
    }
}