using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] GameObject ball;
    float moveX;
    float moveY;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            moveY = -moveY;
        }
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            moveX = -moveX;
        }
    }

    void Start()
    {
        moveX = Random.Range(4f, 6f);
        moveY = Random.Range(4f, 6f);

        float[] directions = { -1f, 1f };

        float xDirection = directions[Random.Range(0, directions.Length)];
        
        float yDirection = directions[Random.Range(0, directions.Length)];

        moveX *= xDirection;
        moveY *= yDirection;
    }


    void FixedUpdate()
    {
        transform.Translate(moveX * Time.fixedDeltaTime, moveY * Time.fixedDeltaTime, 0f);
    }
}
