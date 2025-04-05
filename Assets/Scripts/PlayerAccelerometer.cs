using UnityEngine;

public class PlayerAccelerometer : MonoBehaviour
{
    [SerializeField] private bool useGyro;
    [SerializeField] private float speedM;

    private float scoreRate;
    private int maxHealth;
    private int currentHealth;

    public SpriteRenderer spriteRenderer;
    [SerializeField] private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (useGyro)
        {
            //Input.gyro.enabled = true;
        }
    }

    private void Update()
    {
        float moveInput =  Input.acceleration.y;
        float movement = moveInput * speedM ;

        Vector2 newPosition = rectTransform.anchoredPosition + new Vector2(0, movement);
        newPosition.y = Mathf.Clamp(newPosition.y, -658f, 658f);
        rectTransform.anchoredPosition = newPosition;
        //recttranform -> tranform.position
        Debug.Log("Accel Y: " + Input.acceleration.y);
    }
    public void SetShip(ShipData shipData)
    {
        speedM = shipData.verticalSpeed;
        scoreRate = shipData.scoreRate;
        maxHealth = shipData.life;
        currentHealth = maxHealth;

        if (spriteRenderer != null && shipData.shipSprite != null)
        {
            spriteRenderer.sprite = shipData.shipSprite;
        }
        Debug.Log("Ship set: " + shipData.shipName);
    }
}
