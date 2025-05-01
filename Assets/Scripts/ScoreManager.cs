using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "InfiniteSpaceShooter/Score")]
public class ScoreManager : ScriptableObject
{
    [SerializeField] private NotificationModified _notificationModified;

    public float currentScore;
    public float highScore;

    private float scoreRate;

    public UnityEvent<float> OnScoreChanged;
    public UnityEvent<float> OnHighScoreChanged;

    private void OnEnable()
    {
        if (OnScoreChanged == null)
        {
            OnScoreChanged = new UnityEvent<float>();
        }
        if (OnHighScoreChanged == null)
        {
            OnHighScoreChanged = new UnityEvent<float>();
        }
    }
    public void ResetScore()
    {
        currentScore = 0f;
        OnScoreChanged.Invoke(currentScore);
    }
    public void SetScoreRate(float rate)
    {
        scoreRate = rate;
    }

    public void UpdateScore()
    {
        currentScore += scoreRate * Time.deltaTime;
        OnScoreChanged.Invoke(currentScore);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            OnHighScoreChanged.Invoke(highScore);
            if (_notificationModified != null)
            {
                _notificationModified.SendNewHighScoreNotification();

            }
        }
    }

}