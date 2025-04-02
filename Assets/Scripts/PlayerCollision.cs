using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HealthManager healthManager;

    private void Start()
    {
        healthManager.InitializeHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
        {
            healthManager.TakeDamage(1);
        }
    }
}