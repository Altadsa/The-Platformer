using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D playerRB;
    CapsuleCollider2D playerBody;
    BoxCollider2D playerFeet;

    public Vector2 knockbackForce;

    public float moveSpeed, jumpPower;
    bool jump = false;
    bool isDead = false;

    Layers[] jumpLayers = new Layers[]
    {
        Layers.Platforms,
        Layers.Foreground
    };

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerBody = GetComponent<CapsuleCollider2D>();
        playerFeet = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ChangeDirection();
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDead) { return; }
        Move();
        Jump();
    }

    public void OnPlayerHit(Enemy attacker)
    {
        KnockPlayerBack(attacker);
    }

    public void OnPlayerDeath()
    {
        isDead = true;
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
        bool canJump = CanPlayerJump();
        if (canJump)
        {
            if (jump)
            {
                jump = false;
                Vector2 jumpForce = new Vector2(0, jumpPower * Time.fixedDeltaTime);
                playerRB.velocity += jumpForce;
            }
        }
    }

    private bool CanPlayerJump()
    {
        foreach (Layers layer in jumpLayers)
        {
            int layerMask = 1 << (int)layer;
            if (playerFeet.IsTouchingLayers(layerMask))
            {
                return true;
            }
        }
        return false;
    }

    private void ChangeDirection()
    {
        float direction = playerRB.velocity.x;
        Vector2 tLocalScale = transform.localScale;
        tLocalScale.x = Mathf.Sign(direction);
        transform.localScale = tLocalScale;
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
