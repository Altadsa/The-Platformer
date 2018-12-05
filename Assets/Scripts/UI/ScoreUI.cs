using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

    [SerializeField]
    TMP_Text scoreText;

    private void Awake()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }

    public void OnUIUpdated()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
	}
}
