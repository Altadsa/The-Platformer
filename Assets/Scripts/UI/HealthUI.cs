using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    public Image[] healthImages;

    public Sprite[] sprites;

    public PlayerHealth player;

    private void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (!player) { return; }
        if (PlayerHealth.health < 0) { return; }
        bool active = true;

        for (int i = 0; i < healthImages.Length; i++)
        {
            if (!active)
            {
                healthImages[i].sprite = sprites[0];
            }
            else
            {
                if (PlayerHealth.health >= i)
                {
                    healthImages[i].sprite = sprites[1];
                }
                else
                {
                    active = false;
                }
            }
        }
    }
}
