using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool useGyro;
    public float speedM = 0f;
    
    private float scoreRate;
    private int maxHealth;
    private int currentHealth;

    [SerializeField] private RectTransform rectTransform;

    public SpriteRenderer spriteRenderer;



    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();

        if (useGyro)
        {
            Input.gyro.enabled = true;
            Debug.Log("Gyroscope enabled: " + Input.gyro.enabled);
        }
    }

    private void Update()
    {
        float moveInput = Input.gyro.rotationRateUnbiased.y;
        float movement = moveInput * speedM  ;

        Vector3 newPosition = transform.position + new Vector3(0, movement,0);
        newPosition.y = Mathf.Clamp(newPosition.y, -133f, 133f);

        transform.position = newPosition;

        //Debug.Log("Gyro: " + Input.gyro.rotationRateUnbiased.y);
        Debug.Log($"Gyro active: {Input.gyro.enabled}, Rotation Y: {Input.gyro.rotationRateUnbiased.y}");

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