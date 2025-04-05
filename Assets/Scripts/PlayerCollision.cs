using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    private void Start()
    {
        healthManager.InitializeHealth();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthManager.TakeDamage(1);
        }
    }
}