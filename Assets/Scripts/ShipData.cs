using UnityEngine;

[CreateAssetMenu(fileName = "NewShip", menuName = "InfiniteSpaceShooter/Ship")]
public class ShipData : ScriptableObject
{
    [SerializeField] private string shipName;
    [SerializeField] private Sprite shipSprite;
    [SerializeField] private float life;
    public float verticalSpeed;
    [SerializeField] private float scoreRate;
}