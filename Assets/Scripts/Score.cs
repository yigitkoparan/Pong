using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text playerT;
    [SerializeField] TMP_Text opponentT;
    [SerializeField] GameObject player;
    [SerializeField] GameObject opponent;
    int playerStart = 0;
    int opponentStart = 0;

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
            transform.position = ballStartPos;
        }
        if (collision.CompareTag("PlayerScore"))
        {
            playerStart++;
            playerT.text = playerStart.ToString();

            player.transform.position = playerStartPos;
            opponent.transform.position = opponentStartPos;
            transform.position = ballStartPos;
        }
    }
        

    
}
