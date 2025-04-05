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

        if (selectedShip != null)
        {
            player.SetShip(selectedShip);
            scoreManager.SetScoreRate(selectedShip.scoreRate);
            healthManager.SetMaxHealth(selectedShip.life);
            healthManager.InitializeHealth();
            scoreManager.ResetScore();

            Debug.Log("Ship loaded from GameData: " + selectedShip.shipName);
        }
        else
        {
            Debug.LogWarning("No ship selected in GameData!");
        }
    }

    private void Update()
    {
        scoreManager.UpdateScore();
    }
}