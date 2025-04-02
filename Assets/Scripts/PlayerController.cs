using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool useGyro;
    [SerializeField] private float speed;

    private void Start()
    {
        if (ShipSelection.SelectedShip != null)
        {
            speed = ShipSelection.SelectedShip.verticalSpeed;
        }
    }

    private void Update()
    {
        float moveInput = useGyro ? Input.gyro.rotationRateUnbiased.y : Input.acceleration.y;
        float movement = moveInput * speed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(0, movement, 0);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);
        transform.position = newPosition;
    }
}