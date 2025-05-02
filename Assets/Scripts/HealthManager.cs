using UnityEngine;
using UnityEngine.SceneManagement;
using System;
[CreateAssetMenu(fileName = "HealthManager", menuName = "InfiniteSpaceShooter/Health")]
public class HealthManager : ScriptableObject
{
   
    private float maxHealth;
    public float currentHealth;
    public event Action OnHealthDepleted;

    public void InitializeHealth()
    {
        currentHealth = maxHealth;
    }
    public void SetMaxHealth(float value)
    {
        maxHealth = value;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            SceneGlobalManager.Instance.ShowResults();
            //aqui iria la condicion
            OnHealthDepleted?.Invoke();
        }
    }
}