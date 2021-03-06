﻿using UnityEngine;

public class MovingPlatform : MonoBehaviour {
 
    public float movementSpeed;

    [SerializeField] BoxCollider2D triggerCollider;

    Transform playerParent;

    Layer[] collisionLayers = new Layer[]
    {
        Layer.Foreground,
        Layer.Platforms
    };

    private void Update()
    {
        MovePlatform();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            playerParent = collision.transform.parent;
            collision.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.transform.parent = playerParent;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeDirection();
    }

    private void MovePlatform()
    {
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
    }

    private void ChangeDirection()
    {
        bool hasCollided = Layers.IsColliderTouchingLayers(triggerCollider, collisionLayers);
        if (hasCollided)
        {
            FlipPlatform();
        }
    }

    private void FlipPlatform()
    {
        movementSpeed = -movementSpeed;
        Vector3 localScale = transform.localScale;
        localScale.x = -localScale.x;
        transform.localScale = localScale;
    }

}
