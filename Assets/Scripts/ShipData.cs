using UnityEngine;

[CreateAssetMenu(fileName = "NewShip", menuName = "InfiniteSpaceShooter/Ship")]
public class ShipData : ScriptableObject
{
    public string shipName;
    public Sprite shipSprite;
    public float life;
    public float verticalSpeed;
    public float scoreRate;
}