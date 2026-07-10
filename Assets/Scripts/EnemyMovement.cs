using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] Movement movement;

    void FixedUpdate()
    {
        if(ball.transform.position.x > 0)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = new Vector2(currentPos.x,ball.transform.position.y);

            Vector2 nextPos = Vector2.MoveTowards(currentPos,targetPos,moveSpeed * Time.fixedDeltaTime);

            nextPos.y = Mathf.Clamp(nextPos.y,-movement.getClamp(),movement.getClamp());

            transform.position = nextPos;
        }        
    }
}
