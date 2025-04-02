using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private ColorPalette palette;

    [SerializeField] private Image[] uiElements;
    [SerializeField] private Text[] textElements;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer[] enemySprites;

    private void Start()
    {
        ApplyColors();
    }

    public void ApplyColors()
    {
        Camera.main.backgroundColor = palette.backgroundColor;

        for (int i = 0; i < uiElements.Length; i++)
        {
            uiElements[i].color = palette.buttonColor;
        }

        for (int i = 0; i < textElements.Length; i++)
        {
            textElements[i].color = palette.uiTextColor;
        }

        if (playerSprite != null)
            playerSprite.color = palette.playerColor;

        for (int i = 0; i < enemySprites.Length; i++)
        {
            enemySprites[i].color = palette.enemyColor;
        }
    }
}