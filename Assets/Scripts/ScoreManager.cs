using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
[CreateAssetMenu(fileName = "ScoreManager", menuName = "InfiniteSpaceShooter/Score")]
public class ScoreManager : ScriptableObject
{
    public float currentScore;
    [SerializeField]private float scoreRate;
    [SerializeField] private List<float> scoreRecord = new List<float>();
    
    //public static event Action<float> OnScoreChange;
    public void ResetScore()
    {
        currentScore = 0;
        //OnScoreChange?.Invoke(currentScore);
    }
    private void Awake()
    {
       // currentScore = 0;
        scoreRecord.Clear();
    }

    public void UpdateScore()
    {
        currentScore += scoreRate * Time.deltaTime;
        //OnScoreChange?.Invoke(currentScore);
    }
    public void SetScoreRate(float rate)
    {
        scoreRate = rate;
        
        scoreRecord.Add(currentScore);
        Debug.Log("Score recorded: " + currentScore);
       // OnScoreChange?.Invoke(currentScore);
    }
     public float GetLastRecordedScore()
     {
        //nolouso
         if (scoreRecord.Count == 0) return 0;
         float a = scoreRecord[scoreRecord.Count - 1];
        Debug.Log("Last recorded score: " + a);
        return scoreRecord[scoreRecord.Count - 1];
       
    }
    public void ClearResults()
    {
        scoreRecord.Clear();
        currentScore = 0;
    }
    public void GetHighScore()
    {
       // Debug.Log("wazaaa");
        float maxScore = scoreRecord[0];
        for (int i = 0; i < scoreRecord.Count; i++)
        {
            if (scoreRecord[i] > maxScore)
            {
                maxScore = scoreRecord[i];
                //Debug.Log("ola");// Actualiza si encuentra uno mayor
            }
            
        }
        if (maxScore < currentScore)
        {
            Debug.Log("High Score: creo q curretn es mayor " + currentScore);
        }
    }
    public bool GetHighScoreTest()
    {
        bool isHigh = false;
       // Debug.Log("wazaaa");
        float maxScore = scoreRecord[0];
        for (int i = 0; i < scoreRecord.Count; i++)
        {
            if (scoreRecord[i] > maxScore)
            {
                maxScore = scoreRecord[i];
                //Debug.Log("ola");// Actualiza si encuentra uno mayor
            }

        }
        if (maxScore < currentScore)
        {
            Debug.Log("High Score: creo q curretn es mayor " + currentScore);
            isHigh = true;
        }
        return isHigh;
    }
}