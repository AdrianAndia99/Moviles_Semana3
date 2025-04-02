using UnityEngine;

[CreateAssetMenu(fileName = "ColorPalette", menuName = "InfiniteSpaceShooter/Color Palette")]
public class ColorPalette : ScriptableObject
{
    public Color backgroundColor;
    public Color uiTextColor;
    public Color buttonColor;
    public Color playerColor;
    public Color enemyColor;
}