using UnityEngine;

public class Enemy : MonoBehaviour {

    public BoxCollider2D head;
    public Rigidbody2D enemyRB;

    public float speed;

    bool isActive;

    private void OnBecameVisible()
    {
        isActive = true;
    }

    private void OnBecameInvisible()
    {
        isActive = false;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            enemyRB.velocity = new Vector2(speed * Time.fixedDeltaTime, enemyRB.velocity.y);
            KillIfHitOnHead(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeDirection();
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
