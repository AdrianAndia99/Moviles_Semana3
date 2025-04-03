using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool useGyro;
    [SerializeField] private float speedM;
    
    private float scoreRate;
    private int maxHealth;
    private int currentHealth;
    //private Vector3 startPosition = new Vector3(-10.92f, 1.09f, 0f);

    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (useGyro)
        {
            Input.gyro.enabled = true;
        }
    }
    private void Start()
    {
        //transform.position = startPosition;
    }

    private void Update()
    {
        float moveInput = useGyro ? Input.gyro.rotationRateUnbiased.y : Input.acceleration.y;
        float movement = moveInput * speedM * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(0, movement, 0);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);
        transform.position = newPosition;
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