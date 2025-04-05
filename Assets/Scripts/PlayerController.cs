using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool useGyro;
    private float speedM = 1000f;
    
    private float scoreRate;
    private int maxHealth;
    private int currentHealth;

    [SerializeField] private RectTransform rectTransform;

    public Image spriteRenderer;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        if (useGyro)
        {
            Input.gyro.enabled = true;
            Debug.Log("Gyroscope enabled: " + Input.gyro.enabled);
        }
    }

    private void Update()
    {
        float moveInput = Input.gyro.rotationRateUnbiased.y;
        float movement = moveInput * speedM * Time.deltaTime;

        Vector2 newPosition = rectTransform.anchoredPosition + new Vector2(0, movement);
        newPosition.y = Mathf.Clamp(newPosition.y, -400f, 400f);

        rectTransform.anchoredPosition = newPosition;

        Debug.Log("Gyro: " + Input.gyro.rotationRateUnbiased.y);
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