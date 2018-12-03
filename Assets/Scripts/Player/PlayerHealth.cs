using UnityEngine;
using GEV;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    ScriptableEvent onPlayerHealthChanged;

    public CapsuleCollider2D playerBody;

    public static int health = 3;
    const int maxHealth = 3;

    public void OnLevelStart()
    {
        health = maxHealth;
        onPlayerHealthChanged.Raise();
    }

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
            onPlayerHealthChanged.Raise();
            LevelManager.Instance.ResetLevel();
        }
    }

    public void DecreaseHealth()
    {
        health--;
        onPlayerHealthChanged.Raise();
        if (health <= 0)
        {
            //Destroy(gameObject);
        }
    }

    public void IncreaseHealth()
    {
        if (health < maxHealth)
        {
            health++;
            onPlayerHealthChanged.Raise();
        }

    }

}
