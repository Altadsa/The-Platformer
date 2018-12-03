using UnityEngine;
using GEV;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    ScriptableEvent onPlayerHealthChanged;

    [SerializeField]
    ScriptableEvent onPlayerDeath;

    CapsuleCollider2D playerBody;

    int health = 3;
    const int maxHealth = 3;

    private void Awake()
    {
        playerBody = GetComponent<CapsuleCollider2D>();
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
            onPlayerDeath.Raise();
            GameManager.Instance.OnPlayerDeath();
        }
    }

    public int Health { get { return health; } }

    public void DecreaseHealth()
    {
        health--;
        onPlayerHealthChanged.Raise();
        if (health <= 0)
        {
            onPlayerDeath.Raise();
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
