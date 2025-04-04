using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Enemy collided with wall");
            Destroy(this.gameObject);
        }
    }
}