using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRB;
    public CapsuleCollider2D playerBody;
    public BoxCollider2D playerFeet;

    public float moveSpeed, jumpPower;
    bool jump = false;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        MoveIfHasInput();
    }

    private void MoveIfHasInput()
    {
        float xControlThrow = Input.GetAxisRaw("Horizontal");
        bool hasVelocity = Mathf.Abs(xControlThrow) > Mathf.Epsilon;
        if (hasVelocity)
        {
            float moveX = xControlThrow * moveSpeed * Time.fixedDeltaTime;
            Vector2 moveForce = new Vector2(moveX, 0.0f);
            playerRB.AddForce(moveForce);
            ClampPlayerVelocity();
        }
        else
        {
            Vector2 noHorizontalMovement = new Vector2(0, playerRB.velocity.y);
            playerRB.velocity = noHorizontalMovement;
        }
    }

    private void ClampPlayerVelocity()
    {
        float clampX = Mathf.Clamp(playerRB.velocity.x, -10, 10);
        float clampY = Mathf.Clamp(playerRB.velocity.y, -50, 50);
        playerRB.velocity = new Vector2(clampX, clampY);
    }

    private void Jump()
    {
        bool isTouchingForeground = playerFeet.IsTouchingLayers(LayerMask.GetMask("Foreground"));
        if (isTouchingForeground)
        {
            if (jump)
            {
                jump = false;
                Vector2 jumpForce = new Vector2(0, jumpPower * Time.fixedDeltaTime);
                playerRB.velocity += jumpForce;
            }
        }
    }

}
