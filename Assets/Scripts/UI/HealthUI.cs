using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    public Image[] healthImages;

    public Sprite[] sprites;

    public PlayerHealth player;

    public void OnPlayerHealthChanged()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (!player) { return; }
        if (PlayerHealth.health < 0) { return; }

        for (int i = 0; i < healthImages.Length; i++)
        {
            if (PlayerHealth.health > i)
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
