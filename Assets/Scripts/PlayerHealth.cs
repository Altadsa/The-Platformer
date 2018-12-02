using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public CapsuleCollider2D playerBody;

    public static int health = 3;
    int maxHealth = 3;


    private void Update()
    {
        Die();
    }

    private void Die()
    {
        bool isTouchingHazards = playerBody.IsTouchingLayers(LayerMask.GetMask("Hazards"));
        if (isTouchingHazards)
        {
            health = 0;
            LevelManager.Instance.ResetLevel();
        }
    }

    public void DecreaseHealth()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseHealth()
    {
        if (health < maxHealth)
        {
            health++;
        }

    }

}
