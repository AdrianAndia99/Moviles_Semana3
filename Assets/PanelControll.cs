using UnityEngine;
using UnityEngine.UI;
public class PanelControll : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;


    public Color background;
    public Color text;
    public Color button;
    public Color player;
    public Color enemies;
    // public SpriteRenderer playerRenderer;
    public ColorPalette palette;
    public void UpdateColor()
    {
        float r = redSlider.value;
        float g = greenSlider.value;
        float b = blueSlider.value;

        
    }
    
    public void Background(Button b)
    {
        background = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        b.image.color = background;
        palette.backgroundColor = background;
    }
    public void Text(Button b)
    {
        text = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        b.image.color = text;
        palette.uiTextColor = text;
    }
    public void Button(Button b)
    {
        button = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        b.image.color = button;
        palette.buttonColor = button;
    }
    public void Player(Button b)
    {
        player = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        b.image.color = player;
        palette.playerColor = player;
    }
    public void Enemies(Button b)
    {
        enemies = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        b.image.color = enemies;
        palette.enemyColor = enemies;
    }
    private void Awake()
    {
        if (this != null)
        {
            this.gameObject.SetActive(false);
        }
        background = palette.backgroundColor;
        text = palette.uiTextColor;
        button = palette.buttonColor;
        player = palette.playerColor;
        enemies = palette.enemyColor;

    }
    public void ActivePanelColors()
    {
        this.gameObject.SetActive(true);

    }
    public void InactivePanelColors()
    {
        this.gameObject.SetActive(false);

    }
}
