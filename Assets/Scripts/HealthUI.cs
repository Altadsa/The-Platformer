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


    }
}
