using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text playerT;
    [SerializeField] TMP_Text opponentT;
    [SerializeField] GameObject player;
    [SerializeField] GameObject opponent;
    [SerializeField] BallMovement ball;
    int playerStart = 0;
    int opponentStart = 0;
    float[] directions = { -1f, 1f };

    Vector2 playerStartPos;
    Vector2 opponentStartPos;
    Vector2 ballStartPos;

    void Start()
    {
        playerStartPos = player.transform.position;
        opponentStartPos = opponent.transform.position;
        ballStartPos = transform.position;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OppScore"))
        {
            opponentStart++;
            opponentT.text = opponentStart.ToString();

            player.transform.position = playerStartPos;
            opponent.transform.position = opponentStartPos;
            resetBall();
        }
        if (collision.CompareTag("PlayerScore"))
        {
            playerStart++;
            playerT.text = playerStart.ToString();

            player.transform.position = playerStartPos;
            opponent.transform.position = opponentStartPos;
            resetBall();
        }
    }

    void resetBall()
    {
        transform.position = ballStartPos;
        ball.MoveX = Random.Range(4f, 6f);
        ball.MoveY = Random.Range(4f, 6f);

        ball.XDirection = directions[Random.Range(0, directions.Length)];
        
        ball.YDirection = directions[Random.Range(0, directions.Length)];

        ball.MoveX = ball.MoveX * ball.XDirection;
        ball.MoveY = ball.MoveY * ball.YDirection;
    }
        

    
}
