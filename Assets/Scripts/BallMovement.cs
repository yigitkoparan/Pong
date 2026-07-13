using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    float moveX;
    float moveY;
    float[] directions = { -1f, 1f };
    float xDirection;
    float yDirection;

    public float MoveX
    {
        get {return moveX;}
        set {moveX = value;}
    }

    public float MoveY
    {
        get {return moveY;}
        set {moveY = value;}
    }

    public float XDirection
    {
        get {return xDirection;}
        set {xDirection = value;}
    }

    public float YDirection
    {
        get {return yDirection;}
        set {yDirection = value;}
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            moveY = -moveY;
            audioSource.Play();
        }
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            moveX = -moveX;
            audioSource.Play();
        }
    }

    void Start()
    {
        InitializeBall();
    }

    private void InitializeBall()
    {
        moveX = Random.Range(4f, 6f);
        moveY = Random.Range(4f, 6f);

        xDirection = directions[Random.Range(0, directions.Length)];

        yDirection = directions[Random.Range(0, directions.Length)];

        moveX *= xDirection;
        moveY *= yDirection;
    }

    void FixedUpdate()
    {
        transform.Translate(moveX * Time.fixedDeltaTime, moveY * Time.fixedDeltaTime, 0f);
    }
}
