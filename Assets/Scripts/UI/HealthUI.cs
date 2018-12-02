using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    public Image[] healthImages;

    public PlayerHealth player;

    private void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (!player) { return; }
        if (PlayerHealth.health < 0) { return; }

if (PlayerHealth.health == 3)
        {
            healthImages[2].enabled = true;
            healthImages[1].enabled = true;
            healthImages[0].enabled = true;
        }
else if (PlayerHealth.health == 2)
        {
            healthImages[2].enabled = false;
            healthImages[1].enabled = true;
            healthImages[0].enabled = true;
        }
else if (PlayerHealth.health == 1)
        {
            healthImages[2].enabled = false;
            healthImages[1].enabled = false;
            healthImages[0].enabled = true;
        }
else
        {
            healthImages[2].enabled = false;
            healthImages[1].enabled = false;
            healthImages[0].enabled = false;
        }


    }
}
