using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "HealthManager", menuName = "InfiniteSpaceShooter/Health")]
public class HealthManager : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
    }
}