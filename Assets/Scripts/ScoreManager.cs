using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "InfiniteSpaceShooter/Score")]
public class ScoreManager : ScriptableObject
{
    public float currentScore;
    private float scoreRate;

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void UpdateScore()
    {
        currentScore += scoreRate * Time.deltaTime;
    }
    public void SetScoreRate(float rate)
    {
        scoreRate = rate;
    }
}