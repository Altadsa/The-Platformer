using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRB;
    public CapsuleCollider2D playerBody;
    public BoxCollider2D playerFeet;

    public Vector2 knockbackForce;

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

    public void OnPlayerHit(Enemy attacker)
    {
        KnockPlayerBack(attacker);
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
            StopPlayerMovement();
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

    private void StopPlayerMovement()
    {
        Vector2 noHorizontalMovement = new Vector2(0, playerRB.velocity.y);
        playerRB.velocity = noHorizontalMovement;
    }

    private void KnockPlayerBack(Enemy attacker)
    {
        float attackerX = attacker.transform.position.x;
        float direction = Mathf.Sign(transform.position.x - attackerX);
        knockbackForce.x = knockbackForce.x * direction;
        StopPlayerMovement();
        playerRB.AddForce(knockbackForce);
    }

}
