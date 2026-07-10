using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float yClamp = 4.12f;

    public float getClamp()
    {
        return yClamp;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (rb == null) return;

        Vector2 currentPos = rb.position;
        Vector2 moveDirection = new Vector2(0f, movement.y);
        
        Vector2 newPos = currentPos + moveDirection * (moveSpeed * Time.fixedDeltaTime);
        
        newPos.y = Mathf.Clamp(newPos.y, -yClamp, yClamp);

        rb.MovePosition(newPos);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}