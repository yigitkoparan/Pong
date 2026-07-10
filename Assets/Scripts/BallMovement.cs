using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float moveSpeedX = 5f;
    [SerializeField] float moveSpeedY = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            moveSpeedY = -moveSpeedY;
        }
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            moveSpeedX = -moveSpeedX;
        }
    }

    void FixedUpdate()
    {
        ball.transform.Translate(moveSpeedX*Time.deltaTime,moveSpeedY*Time.fixedDeltaTime,0);
    }
}
