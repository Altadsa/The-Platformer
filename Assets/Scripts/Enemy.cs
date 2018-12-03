using UnityEngine;
using GEV;

public class Enemy : MonoBehaviour {

    [SerializeField]
    EnemyEvent onPlayerHit;

    public CapsuleCollider2D body;
    public BoxCollider2D head;
    public Rigidbody2D enemyRB;

    [SerializeField]
    float speed;

    bool isActive;

    float timeElapsed, attackCD;

    private void OnBecameVisible()
    {
        attackCD = 1.5f;
        timeElapsed = attackCD;
        isActive = true;
    }

    private void OnBecameInvisible()
    {
        isActive = false;
    }

    private void Update()
    {
        if (timeElapsed < attackCD)
        {
            timeElapsed += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            enemyRB.velocity = new Vector2(speed * Time.fixedDeltaTime, enemyRB.velocity.y);
            KillIfHitOnHead(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamagePlayer();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeDirection();
    }

    private void DamagePlayer()
    {
        bool touchingPlayer = body.IsTouchingLayers(LayerMask.GetMask("Player"));
        if (touchingPlayer)
        {
            if (timeElapsed >= attackCD)
            {
                timeElapsed = 0;
                onPlayerHit.Raise(this);
            }
        }
    }

    private void KillIfHitOnHead()
    {
        bool isHeadHit = head.IsTouchingLayers(LayerMask.GetMask("Player"));
        if (isHeadHit)
        {
            Destroy(gameObject);
        }
    }

    private void ChangeDirection()
    {
        speed = -speed;
        Vector3 newLocalScale = transform.localScale;
        newLocalScale.x = -newLocalScale.x;
        transform.localScale = newLocalScale;
    }
}
