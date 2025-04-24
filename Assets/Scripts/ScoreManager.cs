using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "InfiniteSpaceShooter/Score")]
public class ScoreManager : ScriptableObject
{
    public float currentScore;
    private float scoreRate;

    public UnityEvent<float> OnScoreChanged;
    private void OnEnable()
    {
        if (OnScoreChanged == null)
        {
            OnScoreChanged = new UnityEvent<float>();
        }
    }
    public void ResetScore()
    {
        currentScore = 0;
        OnScoreChanged.Invoke(currentScore);
    }

    public void UpdateScore()
    {
        currentScore += scoreRate * Time.deltaTime;
        OnScoreChanged.Invoke(currentScore);
    }
    public void SetScoreRate(float rate)
    {
        scoreRate = rate;
    }
}