using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private ColorPalette palette;

    [SerializeField] private Image[] uiImageElements;
    [SerializeField] private TextMeshProUGUI[] textElements;
    [SerializeField] private Image playerSprite;
    [SerializeField] private SpriteRenderer[] enemySprites;
    [SerializeField] private SpriteRenderer playerInGame;

    private void Start()
    {
        ApplyColors();
    }
    private void Update()
    {
         ApplyColors();
    }
    public void ApplyColors()
    {
        Camera.main.backgroundColor = palette.backgroundColor;

        for (int i = 0; i < uiImageElements.Length; i++)
        {
            Debug.Log("nosewe");    
            uiImageElements[i].color = palette.buttonColor;
        }

        for (int i = 0; i < textElements.Length; i++)
        {
            textElements[i].color = palette.uiTextColor;
        }

        if (playerSprite != null||playerInGame!=null)
            playerSprite.color = palette.playerColor;
            playerInGame.color = palette.playerColor;

        for (int i = 0; i < enemySprites.Length; i++)
        {
            enemySprites[i].color = palette.enemyColor;
        }
    }
}