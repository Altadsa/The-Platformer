using TMPro;
using UnityEngine;

public class TimeLeftUI : MonoBehaviour {

    public TMP_Text timeText;

    private void Update()
    {
        timeText.text = "Time Left: \n" + (int)GameManager.Instance.timeLeft;
    }
}
