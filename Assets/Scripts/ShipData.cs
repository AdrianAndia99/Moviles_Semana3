using UnityEngine;

[CreateAssetMenu(fileName = "NewShip", menuName = "InfiniteSpaceShooter/Ship")]
public class ShipData : ScriptableObject
{
    public string shipName;
    public Sprite shipSprite;
    public int life;
    public float verticalSpeed;
    public float scoreRate;
}