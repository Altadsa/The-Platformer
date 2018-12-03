using TMPro;
using UnityEngine;

public class TimeLeftUI : MonoBehaviour {

    [SerializeField]
    TMP_Text timeText;

    private void Update()
    {
        timeText.text = "Time Left: \n" + (int)GameManager.Instance.TimeLeft;
    }
}
