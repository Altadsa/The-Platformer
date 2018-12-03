using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    public Image[] healthImages;

    public Sprite[] sprites;

    PlayerHealth player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    public void OnPlayerHealthChanged()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (!player) { return; }
        if (player.Health < 0) { return; }

        for (int i = 0; i < healthImages.Length; i++)
        {
            if (player.Health > i)
            {
                healthImages[i].sprite = sprites[1];
            }
            else
            {
                healthImages[i].sprite = sprites[0];
            }
        }
    }
}
