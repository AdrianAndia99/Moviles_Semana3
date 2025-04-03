using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private PlayerController player;

    private void Start()
    {
        if (gameData.selectedShip != null)
        {
            player.SetShip(gameData.selectedShip);
        }
    }
}