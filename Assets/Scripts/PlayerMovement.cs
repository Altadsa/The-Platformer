using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRB;
    public CapsuleCollider2D playerBody;
    public BoxCollider2D playerFeet;

    public float moveSpeed, jumpPower;

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float xControlThrow = Input.GetAxisRaw("Horizontal");
        float moveX = xControlThrow * moveSpeed * Time.fixedDeltaTime;
        Vector2 moveForce = new Vector2(moveX, 0.0f);
        playerRB.AddForce(moveForce);
        ClampPlayerVelocity();
    }

    private void ClampPlayerVelocity()
    {
        float clampX = Mathf.Clamp(playerRB.velocity.x, -25, 25);
        float clampY = Mathf.Clamp(playerRB.velocity.y, -50, 50);
        playerRB.velocity = new Vector2(clampX, clampY);
    }

    private void Jump()
    {
        bool isTouchingForeground = playerFeet.IsTouchingLayers(LayerMask.GetMask("Foreground"));
        if (isTouchingForeground)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Vector2 jumpForce = new Vector2(0, jumpPower * Time.fixedDeltaTime);
                playerRB.velocity += jumpForce;
            }
        }
    }

}
