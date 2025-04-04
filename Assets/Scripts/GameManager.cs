using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private PlayerController player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private HealthManager healthManager;

    private void Start()
    {
       ShipData selectedShip = gameData.selectedShip;
       player.SetShip(gameData.selectedShip);

        if (selectedShip != null)
        {
            scoreManager.SetScoreRate(selectedShip.scoreRate);
            healthManager.SetMaxHealth(selectedShip.life);
            healthManager.InitializeHealth();
            scoreManager.ResetScore();
        }
    }
    private void Update()
    {
        scoreManager.UpdateScore();
    }
}