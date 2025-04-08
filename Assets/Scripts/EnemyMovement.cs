using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField]
    private SimpleObjectPooling obstacleType;
    [SerializeField] private Rigidbody2D myRigidbody;
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Enemy collide");
            isSetUp = false;
            obstacleType.ObjectReturn(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSetUp = false;
            obstacleType.ObjectReturn(this.gameObject);
        }
    }
    private bool isSetUp;

    private void OnEnable()
    {
        obstacleType.onEnableObject += SetUp;
    }

    private void OnDisable()
    {
        obstacleType.onEnableObject -= SetUp;
    }

    private void SetUp()
    {
        if (!isSetUp)
        {
            //TO DO SET UP
            if (myRigidbody == null)
            {
                myRigidbody = GetComponent<Rigidbody2D>();
            }

            myRigidbody.linearVelocity = Vector2.left * speed;

            isSetUp = true;
        }
    }

}