using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static int health = 3;
    int maxHealth = 3;

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
