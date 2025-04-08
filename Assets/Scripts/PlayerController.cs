using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool useGyro;
    public float speedM = 0f;
    
    private float scoreRate;
    private int maxHealth;
    private int currentHealth;

    public SpriteRenderer spriteRenderer;

    [SerializeField] private ProjectilePoolSO projectilePool;
    [SerializeField] private Transform firePoint;
    private float fireRate;

    private bool isFiring = false;
    private float nextFireTime;

    private void Awake()
    {
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
        newPosition.y = Mathf.Clamp(newPosition.y, -3.9f, 5.6f);

        transform.position = newPosition;

        Debug.Log($"Gyro active: {Input.gyro.enabled}, Rotation Y: {Input.gyro.rotationRateUnbiased.y}");

        if (Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Ended)
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }

        if (isFiring && Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate;
        }

    }
    public void SetShip(ShipData shipData)
    {
        speedM = shipData.verticalSpeed;
        scoreRate = shipData.scoreRate;
        maxHealth = shipData.life;
        currentHealth = maxHealth;
        fireRate = shipData.cadence;

        if (spriteRenderer != null && shipData.shipSprite != null)
        {
            spriteRenderer.sprite = shipData.shipSprite;
        }
        Debug.Log("Ship set: " + shipData.shipName);
    }
    private void FireProjectile()
    {
        GameObject projectile = projectilePool.GetPooledObject();
        if (projectile != null)
        {
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = Quaternion.identity;
            projectile.SetActive(true);
        }
    }
}