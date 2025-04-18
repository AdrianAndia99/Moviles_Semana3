using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewShip", menuName = "InfiniteSpaceShooter/Ship")]
public class ShipData : ScriptableObject
{
    public string shipName;
    public Sprite shipSprite;
    public SpriteRenderer shipSpriteGame;
    public int life;
    public float verticalSpeed;
    public int scoreRate;
    public float cadence;
}