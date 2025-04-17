using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "HealthManager", menuName = "InfiniteSpaceShooter/Health")]
public class HealthManager : ScriptableObject
{
    private float maxHealth;
    public float currentHealth;

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
        }
    }
}